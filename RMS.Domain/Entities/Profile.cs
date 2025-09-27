using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Domain.Entities
{
    public class Profile
    {
        public int Id { get; set; }

        [Required]
        public string ResumeFileAddress { get; set; } = "";

        [MaxLength(500)]
        public string Skills { get; set; } = "";

        [MaxLength(500)]
        public string Education { get; set; } = "";

        [MaxLength(500)]
        public string Experience { get; set; } = "";

        [Phone]
        public string Phone { get; set; } = "";

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
