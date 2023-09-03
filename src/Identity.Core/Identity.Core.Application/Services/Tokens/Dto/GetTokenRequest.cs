namespace Identity.Core.Application.Services.Tokens.Dto
{
    public class GetTokenRequest
    {
        public string Login { get; set; }   
        
        public string Password { get; set; }
    }
}