using Notely.Domain.Users;
using Notely.Domain.Users.DataStructures;

namespace Notely.Application.Users
{
    public interface IUsersService : IService
    {
        User RegisterUser(CreateUserDataStructure dataStructure, string password, string confirmPassword);
        User Login(string userName, string password);

    }
}