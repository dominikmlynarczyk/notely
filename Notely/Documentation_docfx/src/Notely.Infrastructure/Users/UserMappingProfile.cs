using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Notely.Domain.Users;
using Notely.SharedKernel;

namespace Notely.Infrastructure.Users
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserEntity>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id.Id));

            CreateMap<UserEntity, User>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id));

            CreateMap<Guid, AggregateId>().ConstructUsing(x => new AggregateId(x));
        }
    }
}
