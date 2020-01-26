using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Notely.Application.Users.DTOs;
using Notely.Application.Users.Queries;
using Notely.SharedKernel.Application.Handlers;

namespace Notely.Application.Users.Handlers
{
    public class GetUserInfoQueryHandler : IQueryHandler<GetUserInfoQuery, UserDto>
    {
        private readonly IUsersService _usersService;

        public GetUserInfoQueryHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task<UserDto> Handle(GetUserInfoQuery query)
        {
            var user = await _usersService.GetUser(query.UserId);
            return new UserDto()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id.Id,
                SecondName = user.SecondName,
                UserName = user.UserName
            };
        }
    }
}
