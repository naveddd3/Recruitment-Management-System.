using System.ComponentModel.DataAnnotations;

namespace RMS.Application.DTOs
{
    public class SignupRequestDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, ErrorMessage = "Address can't be longer than 200 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "User type is required")]
        [RegularExpression("Admin|Applicant", ErrorMessage = "UserType must be Admin, Applicant")]
        public string UserType { get; set; }

        [StringLength(150, ErrorMessage = "Profile headline can't be longer than 150 characters")]
        public string ProfileHeadline { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }
    }
}
