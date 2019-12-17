using System;
using System.Collections.Generic;
using System.Text;
using Notely.SharedKernel;
using Notely.SharedKernel.Application;

namespace Notely.Application.Users.Commands
{
    public class RegisterUserCommand : ICommand
    {
        public AggregateId Id { get; private set; }
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }

        public RegisterUserCommand(string userName, string firstName, string secondName, string email, string password, string confirmPassword)
        {
            Id = new AggregateId(Guid.NewGuid());
            UserName = userName;
            FirstName = firstName;
            SecondName = secondName;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
