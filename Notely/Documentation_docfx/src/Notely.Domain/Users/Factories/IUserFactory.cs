using Notely.Domain.Users.DataStructures;

namespace Notely.Domain.Users.Factories
{
    public interface IUserFactory : IDomainFactory
    {
        User Create(CreateUserDataStructure dataStructure);
    }
}
