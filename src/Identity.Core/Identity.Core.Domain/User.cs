using Identity.Core.Common;

namespace Identity.Core.Domain
{
    public class User
    {
        public Guid Id { get; private set; }
        
        public string Login { get; private set; }
        
        public string PasswordHash { get; private set; }

        public User(string login, string passwordHash)
        {
            Id = Guid.NewGuid();
            Login = login;
            PasswordHash = passwordHash;
        }

        public void ChangePassword(string previousPasswordHash, string newPasswordHash)
        {
            if (PasswordHash != previousPasswordHash)
            {
                throw new DomainException("Change password failed: given password is not equal to current password");
            }

            PasswordHash = newPasswordHash;
        }
        
        private User() {}
    }
}