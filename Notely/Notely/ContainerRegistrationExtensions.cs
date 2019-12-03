using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Notely.Domain;
using Notely.Domain.Users;

namespace Notely
{
    public static class ContainerRegistrationExtensions
    {
        private static Assembly _domainAssembly = typeof(User).Assembly;
        public static ContainerBuilder RegisterDomainFactories(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(_domainAssembly).Where(
                x => x.IsAssignableTo<IDomainFactory>()).AsImplementedInterfaces().InstancePerLifetimeScope();

            return builder;
        }
    }
}
