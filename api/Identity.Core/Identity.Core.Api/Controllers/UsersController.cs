using Identity.Core.Application.Services.Users;
using Identity.Core.Application.Services.Users.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Core.Api.Controllers
{
    [Route("api/Users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<Guid> Register(RegisterUserRequest request)
        {
            return await _userService.Register(request);
        }

        [HttpPut("ChangePassword")]
        public async Task ChangePassword(ChangePasswordRequest request)
        {
            await _userService.ChangePassword(request);
        }
    }
}