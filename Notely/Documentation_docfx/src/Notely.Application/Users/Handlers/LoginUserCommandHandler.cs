using System.Threading.Tasks;
using Notely.Application.Users.Commands;
using Notely.SharedKernel.Application.Handlers;

namespace Notely.Application.Users.Handlers
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand>
    {
        private readonly IUsersService _usersService;

        public LoginUserCommandHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task Handle(LoginUserCommand command)
        {
            await _usersService.Login(command.UserName, command.Password);
        }
    }
}