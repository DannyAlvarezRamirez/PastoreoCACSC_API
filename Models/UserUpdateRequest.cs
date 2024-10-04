namespace PastoreoCACSC_API.Models
{
    public class UserUpdateRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public decimal RolId { get; set; }
        public string ModificadoPor { get; set; }
    }
}
