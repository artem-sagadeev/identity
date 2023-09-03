using Identity.Core.Application.Services.Tokens;
using Identity.Core.Application.Services.Tokens.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Core.Api.Controllers
{
    [Route("/api/Token")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<string> Get(GetTokenRequest request)
        {
            return await _tokenService.GetToken(request);
        }
    }
}