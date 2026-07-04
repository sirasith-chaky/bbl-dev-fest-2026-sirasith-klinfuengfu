using System.ComponentModel.DataAnnotations;

namespace bbl_dev_fest_2026_sirasith_klinfuengfu.Models
{
    public class UserRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required.")]
        public string username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email must be a valid email address.")]
        public string email { get; set; } = string.Empty;

        public string? phone { get; set; }

        public string? website { get; set; }
    }
}
