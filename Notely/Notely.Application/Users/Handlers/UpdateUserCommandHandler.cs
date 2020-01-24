using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Notely.Application.Users.Commands;
using Notely.Domain.Users.DataStructures;
using Notely.SharedKernel.Application.Handlers;

namespace Notely.Application.Users.Handlers
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IUsersService _usersService;

        public UpdateUserCommandHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task Handle(UpdateUserCommand command)
        {
            await _usersService.UpdateUser(new CreateUserDataStructure(command.Id, command.UserName, command.FirstName, command.SecondName,
                command.Email));
        }
    }
}
