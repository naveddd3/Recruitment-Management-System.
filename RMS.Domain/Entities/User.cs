using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RMS.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = "";

        [Required, EmailAddress, MaxLength(200)]
        public string Email { get; set; } = "";

        [Required, MaxLength(250)]
        public string Address { get; set; } = "";

        [Required]
        [RegularExpression("^(Admin|Applicant)$", ErrorMessage = "UserType must be either Admin or Applicant")]
        public string UserType { get; set; } = "";

        [Required, MinLength(8)]
        public string PasswordHash { get; set; } = "";

        [MaxLength(150)]
        public string ProfileHeadline { get; set; } = "";

        public Profile? Profile { get; set; }
    }
}
