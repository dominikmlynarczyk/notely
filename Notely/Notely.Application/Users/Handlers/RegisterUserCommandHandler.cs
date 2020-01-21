using System;
using System.Collections.Generic;
using System.Text;
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

        public void Handle(RegisterUserCommand command)
        {
            _usersService.RegisterUser(new CreateUserDataStructure(
                    command.Id, command.UserName, command.FirstName, command.SecondName, command.Email),
                command.Password,
                command.ConfirmPassword);
        }
    }
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand>
    {
        private readonly IUsersService _usersService;

        public LoginUserCommandHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public void Handle(LoginUserCommand command)
        {
            _usersService.Login(command.UserName, command.Password);
        }
    }
}
