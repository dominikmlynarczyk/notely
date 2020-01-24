using System;
using Notely.SharedKernel;
using Notely.SharedKernel.Application;

namespace Notely.Application.Users.Commands
{
    public class UpdateUserCommand : ICommand
    {
        public AggregateId Id { get; private set; }
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string Email { get; private set; }

        public UpdateUserCommand(Guid id, string userName, string firstName, string secondName, string email)
        {
            Id = new AggregateId(id);
            UserName = userName;
            FirstName = firstName;
            SecondName = secondName;
            Email = email;
        }
    }
}