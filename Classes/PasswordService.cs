using System.Security.Cryptography;
using System.Text;

namespace PastoreoCACSC_API.Classes
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            var salt = GenerateSalt();
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = salt + password;
                var hash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword)));

                // Return the salt and hash in the format "salt:hash"
                return $"{salt}:{hash}";
            }
        }

        public bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split(':');
            if (parts.Length != 2) return false;

            var salt = parts[0];
            var hash = parts[1];

            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = salt + password;
                var computedHash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword)));

                return computedHash == hash;
            }
        }

        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }
    }
}
