using System;
using System.Collections.Generic;
using System.Text;
using Notely.Domain.Users;
using Notely.SharedKernel.Infrastructure.Repositories;

namespace Notely.Infrastructure.Users
{
    public interface IUsersRepository : IGenericRepository<User, UserEntity>, IRepository
    {
    }

}
