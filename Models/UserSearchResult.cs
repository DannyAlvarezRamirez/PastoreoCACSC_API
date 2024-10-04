namespace PastoreoCACSC_API.Models
{
    public class UserSearchResult
    {
        public decimal Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? AccountStatus { get; set; }
        public decimal? RolId { get; set; }
    }
}
