namespace PastoreoCACSC_API.Classes
{
    public interface IJwtTokenService
    {
        string GenerateToken(string username);
    }
}
