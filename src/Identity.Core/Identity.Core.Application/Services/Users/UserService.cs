using Identity.Core.Application.Services.Users.Dto;
using Identity.Core.Application.Utilities;
using Identity.Core.Common;
using Identity.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Identity.Core.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IIdentityContext _context;

        public UserService(IIdentityContext context)
        {
            _context = context;
        }

        public async Task<Guid> Register(RegisterUserRequest request)
        {
            var passwordHash = Cipher.GetPasswordHash(request.Password);
            var user = new User(request.Login, passwordHash);
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task ChangePassword(ChangePasswordRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == request.UserId);

            if (user is null)
            {
                throw new EntityNotFoundException(typeof(User), request.UserId);
            }
            
            var previousPasswordHash = Cipher.GetPasswordHash(request.PreviousPassword);
            var newPasswordHash = Cipher.GetPasswordHash(request.NewPassword);
            user.ChangePassword(previousPasswordHash, newPasswordHash);
        }
    }
}