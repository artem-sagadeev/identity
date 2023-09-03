namespace Identity.Core.Application.Services.Users.Dto
{
    public class ChangePasswordRequest
    {
        public Guid UserId { get; set; }
        
        public string PreviousPassword { get; set; }
        
        public string NewPassword { get; set; }
    }
}