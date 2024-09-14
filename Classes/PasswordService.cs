namespace PastoreoCACSC_API.Classes
{
    public class PasswordService : IPasswordService
    {
        // Skip hashing and return the plain password as is.
        public string HashPassword(string password)
        {
            // Simply return the password (no hashing)
            return password;
        }

        // Compare plain text password with the stored password.
        public bool VerifyPassword(string password, string storedPassword)
        {
            // Simply compare the plain password and the stored password
            return password == storedPassword;
        }
    }
}
