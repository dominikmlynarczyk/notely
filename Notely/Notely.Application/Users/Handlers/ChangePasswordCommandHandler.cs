using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Notely.Application.Users.Commands;
using Notely.SharedKernel.Application.Handlers;

namespace Notely.Application.Users.Handlers
{
    public class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
    {
        private readonly IUsersService _usersService;

        public ChangePasswordCommandHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task Handle(ChangePasswordCommand command)
        {
            await _usersService.ChangePassword(command.UserId, command.OldPassword, command.NewPassword,
                command.ConfirmPassword);
        }
    }
}
