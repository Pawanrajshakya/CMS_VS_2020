using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos
{
    public class UserDto
    {
        [Required]
        [MinLength(6, ErrorMessage="Minimum length for username is 6")]
        public string Username { get; set; }
        [Required]
        [MinLength(8, ErrorMessage="Minimum length for password is 8")]
        public string Password { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Email { get; set; }
        public int[] UserRole { get; set; }
        public bool IsActive { get; set; }
    }
}