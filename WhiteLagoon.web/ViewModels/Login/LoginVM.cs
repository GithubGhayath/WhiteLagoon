using System.ComponentModel.DataAnnotations;

namespace WhiteLagoon.web.ViewModels.Login
{
    public class LoginVM
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
