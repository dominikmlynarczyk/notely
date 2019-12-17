using Notely.Domain.Users;
using Notely.Domain.Users.DataStructures;
using Notely.Domain.Users.Factories;
using Notely.Domain.Users.Policies;
using Notely.Infrastructure.Users;
using Notely.SharedKernel.Exceptions;

namespace Notely.Application.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUserFactory _userFactory;
        private readonly IPasswordPolicyFactory _passwordPolicyFactory;

        public UsersService(IUsersRepository usersRepository, IUserFactory userFactory, IPasswordPolicyFactory passwordPolicyFactory)
        {
            _usersRepository = usersRepository;
            _userFactory = userFactory;
            _passwordPolicyFactory = passwordPolicyFactory;
        }

        public User RegisterUser(CreateUserDataStructure dataStructure, string password, string confirmPassword)
        {
            var user = _userFactory.Create(dataStructure);
            CheckPasswords(password, confirmPassword);
            user.SetPassword(password, _passwordPolicyFactory.Create<FourLettersPasswordPolicy>());

            _usersRepository.Add(user);
            return user;
        }

        public User Login(string userName, string password)
        {
            var user = _usersRepository.Get(x => x.UserName == userName);
            if (user == null)
            {
                throw new BusinessLogicException("Incorrect credentials");
            }

            if (!user.IsPasswordValid(password))
            {
                throw new BusinessLogicException("Incorrect credentials");
            }

            return user;
        }

        private void CheckPasswords(string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                throw new BusinessLogicException("Passwords are not same");
            }
        }
    }
}
