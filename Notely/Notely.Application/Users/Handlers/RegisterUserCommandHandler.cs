using System.Threading.Tasks;
using Notely.Application.Users.Commands;
using Notely.Domain.Users.DataStructures;
using Notely.SharedKernel.Application.Handlers;

namespace Notely.Application.Users.Handlers
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IUsersService _usersService;

        public RegisterUserCommandHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task Handle(RegisterUserCommand command)
        {
            await _usersService.RegisterUser(new CreateUserDataStructure(
                    command.Id, command.UserName, command.FirstName, command.SecondName, command.Email),
                command.Password,
                command.ConfirmPassword);
        }
    }
}
