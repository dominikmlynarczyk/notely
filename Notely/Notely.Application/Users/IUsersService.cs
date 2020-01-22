using System.Threading.Tasks;
using Notely.Domain.Users;
using Notely.Domain.Users.DataStructures;

namespace Notely.Application.Users
{
    public interface IUsersService : IService
    {
        Task<User> RegisterUser(CreateUserDataStructure dataStructure, string password, string confirmPassword);
        Task<User> Login(string userName, string password);

    }
}