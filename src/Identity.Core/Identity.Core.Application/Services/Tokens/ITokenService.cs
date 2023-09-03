using Identity.Core.Application.Services.Tokens.Dto;

namespace Identity.Core.Application.Services.Tokens
{
    public interface ITokenService
    {
        Task<string> GetToken(GetTokenRequest request);
    }
}