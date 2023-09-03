using Identity.Core.Application.Services.Users.Dto;

namespace Identity.Core.Application.Services.Users
{
    public interface IUserService
    {
        Task<Guid> Register(RegisterUserRequest request);

        Task ChangePassword(ChangePasswordRequest request);
    }
}