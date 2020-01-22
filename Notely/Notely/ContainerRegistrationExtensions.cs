using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Autofac;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Notely.Application;
using Notely.Application.Users;
using Notely.Domain;
using Notely.Domain.Users;
using Notely.Infrastructure;
using Notely.Infrastructure.Users;
using Notely.SharedKernel.Application.Handlers;
using Notely.SharedKernel.Infrastructure.Repositories;
using Notely.UserControls;

namespace Notely
{
    public static class ContainerRegistrationExtensions
    {
        private static Assembly _domainAssembly = typeof(User).Assembly;
        private static Assembly _infrastructureAssembly = typeof(UserEntity).Assembly;
        private static Assembly _applicationAssembly = typeof(UsersService).Assembly;
        public static ContainerBuilder RegisterDomainFactories(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(_domainAssembly).Where(
                x => x.IsAssignableTo<IDomainFactory>()).AsImplementedInterfaces().InstancePerLifetimeScope();

            return builder;
        }
        public static ContainerBuilder RegisterRepositories(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericEfRepository<,>)).As(typeof(IGenericRepository<,>));
            builder.RegisterAssemblyTypes(_infrastructureAssembly).Where(
                x => x.IsAssignableTo<IRepository>()).AsImplementedInterfaces().InstancePerLifetimeScope();

            return builder;
        }

        public static ContainerBuilder RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(_applicationAssembly).Where(
                x => x.IsAssignableTo<IService>()).AsImplementedInterfaces().InstancePerLifetimeScope();

            return builder;
        }

        public static ContainerBuilder RegisterCommandHandlers(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(_applicationAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>));

            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
            return builder;
        }

        public static ContainerBuilder RegisterQueryHandlers(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(_applicationAssembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>));

            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
            return builder;
        }

        public static ContainerBuilder RegisterMapper(this ContainerBuilder builder)
        {
            builder.Register(ctx =>
            {
                var assemblies = new List<Assembly>
                {
                    _applicationAssembly,
                    _domainAssembly,
                    _infrastructureAssembly
                };

                var mapperConfig = new MapperConfiguration(x =>
                    x.AddProfiles(assemblies));

                return mapperConfig.CreateMapper();
            }).As<IMapper>().InstancePerLifetimeScope();

            return builder;
        }

        public static ContainerBuilder RegisterDbContext(this ContainerBuilder builder, string connectionString)
        {
            var options = new DbContextOptionsBuilder<NotelyDbContext>().UseSqlite(connectionString).Options;
            builder.Register(c => new NotelyDbContext(options)).As<DbContext>().AsSelf();
            return builder;
        }

        public static ContainerBuilder RegisterSession(this ContainerBuilder builder)
        {
            builder.RegisterType<Session>().As<ISession>().SingleInstance();
            return builder;
        }

        public static ContainerBuilder RegisterUserControls(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(INotelyControl).Assembly)
                .Where(x => x.IsAssignableTo<INotelyControl>()).AsImplementedInterfaces();
            return builder;
        }
    }
}
