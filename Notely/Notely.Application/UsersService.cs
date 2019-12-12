using System;
using System.Collections.Generic;
using System.Text;
using Notely.Domain.Users;
using Notely.Infrastructure.Users;

namespace Notely.Application
{
    public class UsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User Add()
        {
            var user = new User();
            user.SetPassword("asdadad");

            _usersRepository.Save(user);
        }
    }
}
