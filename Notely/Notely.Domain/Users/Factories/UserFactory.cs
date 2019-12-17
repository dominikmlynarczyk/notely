using Notely.Domain.Users.DataStructures;

namespace Notely.Domain.Users.Factories
{
    public class UserFactory : IUserFactory
    {
        public User Create(CreateUserDataStructure dataStructure)
            => new User(dataStructure.Id, dataStructure.UserName, dataStructure.FirstName, dataStructure.SecondName, dataStructure.Email);
    }
}