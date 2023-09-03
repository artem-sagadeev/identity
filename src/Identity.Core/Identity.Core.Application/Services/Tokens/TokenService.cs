using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Identity.Core.Application.Services.Tokens.Dto;
using Identity.Core.Application.Utilities;
using Identity.Core.Common;
using Identity.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Core.Application.Services.Tokens
{
    public class TokenService : ITokenService
    {
        private const string UserIdClaimName = "user_id";
        private const string Secret = "supermegasecretkey";
        
        private readonly IIdentityContext _context;

        public TokenService(IIdentityContext context)
        {
            _context = context;
        }

        public async Task<string> GetToken(GetTokenRequest request)
        {
            var passwordHash = Cipher.GetPasswordHash(request.Password);
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Login == request.Login &&
                                                                        user.PasswordHash == passwordHash);
            if (user is null)
            {
                throw new EntityNotFoundException(typeof(User));
            }
            
            var handler = new JwtSecurityTokenHandler();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var identity = new ClaimsIdentity(new GenericIdentity(user.Login), 
                new[] { new Claim(UserIdClaimName, user.Id.ToString()) });
            var token = handler.CreateJwtSecurityToken(
                subject: identity,
                signingCredentials: signingCredentials);
            return handler.WriteToken(token);
        }
    }
}