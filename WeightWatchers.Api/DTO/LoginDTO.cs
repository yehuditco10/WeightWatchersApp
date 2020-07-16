using System.ComponentModel.DataAnnotations;

namespace WeightWatchers.Api.DTO
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
