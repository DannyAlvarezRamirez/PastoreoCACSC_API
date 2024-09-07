namespace PastoreoCACSC_API.Classes
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string storedHash);
    }
}
