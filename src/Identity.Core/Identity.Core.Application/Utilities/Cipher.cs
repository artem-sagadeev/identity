namespace Identity.Core.Application.Utilities
{
    public static class Cipher
    {
        public const string Salt = "$2a$11$QoRXAHNfUj9Mn/6F3te9ze";
        
        public static string GetPasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, Salt);
        }
    }
}