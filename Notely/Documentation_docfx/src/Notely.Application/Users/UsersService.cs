using System;
using System.Threading.Tasks;
using Notely.Domain.Users;
using Notely.Domain.Users.DataStructures;
using Notely.Domain.Users.Factories;
using Notely.Domain.Users.Policies;
using Notely.Infrastructure;
using Notely.Infrastructure.Users;
using Notely.SharedKernel;
using Notely.SharedKernel.Exceptions;

namespace Notely.Application.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUserFactory _userFactory;
        private readonly IPasswordPolicyFactory _passwordPolicyFactory;
        private readonly ISession _session;

        public UsersService(IUsersRepository usersRepository, IUserFactory userFactory, IPasswordPolicyFactory passwordPolicyFactory, ISession session)
        {
            _usersRepository = usersRepository;
            _userFactory = userFactory;
            _passwordPolicyFactory = passwordPolicyFactory;
            _session = session;
        }

        public async Task<User> RegisterUser(CreateUserDataStructure dataStructure, string password, string confirmPassword)
        {
            var user = await _usersRepository.Get(x => x.UserName == dataStructure.UserName);
            if (user != null)
            {
                throw new BusinessLogicException("UserExistsMessage");
            }
            user = _userFactory.Create(dataStructure);
            CheckPasswords(password, confirmPassword);
            user.SetPassword(password, _passwordPolicyFactory.Create<FourLettersPasswordPolicy>());

            await _usersRepository.Add(user);
            return user;
        }

        public async Task<User> Login(string userName, string password)
        {
            var user = await _usersRepository.Get(x => x.UserName == userName && !x.IsArchived);
            if (user == null)
            {
                throw new BusinessLogicException("InvalidCredentialMessage");
            }

            if (!user.IsPasswordValid(password))
            {
                throw new BusinessLogicException("InvalidCredentialMessage");
            }

            _session.UserId = user.Id.Id;
            _session.UserName = user.UserName;
            _session.FullName = $"{user.FirstName} {user.SecondName}";
            return user;
        }

        public async Task<User> GetUser(AggregateId userId) => await _usersRepository.Get(x => x.Id == userId.Id);
        public async Task UpdateUser(CreateUserDataStructure dataStructure)
        {
            var user = await GetUserOrThrow(dataStructure.Id);
            user.Update(dataStructure.UserName, dataStructure.FirstName, dataStructure.SecondName, dataStructure.Email);
            await _usersRepository.Update(user);
        }
        public async Task DeleteUser(AggregateId id)
        {
            var user = await GetUserOrThrow(id);
            user.Archive();
            await _usersRepository.Update(user);
        }

        public async Task ChangePassword(AggregateId userId, string oldPassword, string newPassword,
            string confirmPassword)
        {
            var user = await GetUserOrThrow(userId);
            if (!user.IsPasswordValid(oldPassword))
            {
                throw new BusinessLogicException("InvalidCredentialMessage");
            }

            CheckPasswords(newPassword, confirmPassword);
            user.SetPassword(newPassword, _passwordPolicyFactory.Create<FourLettersPasswordPolicy>());
            await _usersRepository.Update(user);
        }

        private async Task<User> GetUserOrThrow(AggregateId id)
        {
            var user = await _usersRepository.Get(x => x.Id == id.Id && !x.IsArchived);
            if (user == null)
            {
                throw new BusinessLogicException("UserNotFoundMessage");
            }

            return user;
        }

        private void CheckPasswords(string password, string confirmPassword)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (confirmPassword == null) throw new ArgumentNullException(nameof(confirmPassword));
            if (!password.Equals(confirmPassword))
            {
                throw new BusinessLogicException("PasswordsNotMatchMessage");
            }
        }
    }
}
