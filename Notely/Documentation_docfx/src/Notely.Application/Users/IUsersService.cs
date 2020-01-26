using System;
using System.Threading.Tasks;
using Notely.Domain.Users;
using Notely.Domain.Users.DataStructures;
using Notely.SharedKernel;

namespace Notely.Application.Users
{
    public interface IUsersService : IService
    {
        Task<User> RegisterUser(CreateUserDataStructure dataStructure, string password, string confirmPassword);
        Task<User> Login(string userName, string password);

        Task<User> GetUser(AggregateId userId);
        Task UpdateUser(CreateUserDataStructure dataStructure);
        Task DeleteUser(AggregateId id);

        Task ChangePassword(AggregateId userId, string oldPassword, string newPassword,
            string confirmPassword);
    }
}