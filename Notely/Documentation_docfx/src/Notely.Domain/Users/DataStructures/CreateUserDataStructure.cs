using System;
using System.Collections.Generic;
using System.Text;
using Notely.SharedKernel;

namespace Notely.Domain.Users.DataStructures
{
    public class CreateUserDataStructure
    {
        public AggregateId Id { get; private set; }
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string Email { get; private set; }

        public CreateUserDataStructure(AggregateId id, string userName, string firstName, string secondName, string email)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            SecondName = secondName;
            Email = email;
        }

        private CreateUserDataStructure()
        {
        }
    }
}
