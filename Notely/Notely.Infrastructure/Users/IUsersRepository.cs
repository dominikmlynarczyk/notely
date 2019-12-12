using System;
using System.Collections.Generic;
using System.Text;
using Notely.Domain.Users;

namespace Notely.Infrastructure.Users
{
    public interface IUsersRepository
    {
        void Save(User user);
    }
}
