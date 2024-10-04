namespace PastoreoCACSC_API.Models
{
    public class UserFilterRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public decimal RolId { get; set; }
        public string AccountStatus { get; set; }
    }
}
