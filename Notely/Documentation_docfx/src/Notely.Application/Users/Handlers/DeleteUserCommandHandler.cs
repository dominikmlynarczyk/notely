using System.Threading.Tasks;
using Notely.Application.Users.Commands;
using Notely.SharedKernel.Application.Handlers;

namespace Notely.Application.Users.Handlers
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IUsersService _usersService;

        public DeleteUserCommandHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task Handle(DeleteUserCommand command)
        {
            await _usersService.DeleteUser(command.Id);
        }
    }
}