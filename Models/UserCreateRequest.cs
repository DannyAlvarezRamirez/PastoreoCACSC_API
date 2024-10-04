namespace PastoreoCACSC_API.Models
{
    public class UserCreateRequest
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal RolId { get; set; }
        public string CreadoPor { get; set; }
    }
}
