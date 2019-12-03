using System;
using Notely.Domain.Users.Policies;
using Notely.SharedKernel;
using Notely.SharedKernel.Exceptions;

namespace Notely.Domain.Users
{
    public class User : AggregateRoot
    {
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        private readonly IPasswordPolicyFactory _passwordPolicyFactory;

        private User()
        {
        }
        public User(AggregateId id, string userName, string firstName, string secondName, string email, IPasswordPolicyFactory passwordPolicyFactory) : base(id)
        {
            _passwordPolicyFactory = passwordPolicyFactory;
            SetUserName(userName);
            SetFirstName(firstName);
            SetSecondName(secondName);
            SetEmail(email);
        }

        public void SetPassword(string password)
        {
            var policy = _passwordPolicyFactory.Create<FourLettersPasswordPolicy>();
            if (policy.IsPasswordValid(password))
            {
                throw new BusinessLogicException("Password doesn't match requirements.");
            }

            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password, 13);
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            Email = email;
        }

        private void SetSecondName(string secondName)
        {
            if (string.IsNullOrWhiteSpace(secondName))
            {
                throw new ArgumentNullException(nameof(secondName));
            }

            SecondName = secondName;
        }

        private void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            FirstName = firstName;
        }

        private void SetUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            UserName = userName;
        }
    }
}
