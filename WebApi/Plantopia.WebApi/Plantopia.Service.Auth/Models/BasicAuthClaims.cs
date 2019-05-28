using System.ComponentModel.DataAnnotations;

namespace Plantopia.Service.Auth.Models
{
    public class BasicAuthClaims
    {
        public BasicAuthClaims()
        {
        }

        public BasicAuthClaims(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [Required]
        [EmailAddress]
        [StringLength(64)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(32)]
        public string Password { get; set; }
    }
}
