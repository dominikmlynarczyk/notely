using Notely.SharedKernel.Application;

namespace Notely.Application.Users.Commands
{
    public class LoginUserCommand : ICommand
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public LoginUserCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}