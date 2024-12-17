using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;

namespace WebShopApp.Infrastructure.Data
{
    public class ApplicationUser:IdentityUser
    {

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Adress { get; set; } = null!;
    }
}
