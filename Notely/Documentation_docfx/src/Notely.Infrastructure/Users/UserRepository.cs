using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Notely.Domain.Users;
using Notely.SharedKernel.Infrastructure.Repositories;

namespace Notely.Infrastructure.Users
{
    public class UserRepository : GenericEfRepository<User, UserEntity>, IUsersRepository
    {
        public UserRepository(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
