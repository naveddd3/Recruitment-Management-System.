using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Application.DTOs
{
    public class ApplicantDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
        public string UserType { get; set; } = "";
        public string ProfileHeadline { get; set; } = "";

        // ✅ Profile info
        public ProfileDto? Profile { get; set; }
    }
    public class ProfileDto
    {
        public string ResumeFileAddress { get; set; } = "";
        public List<string> Skills { get; set; } = new();
        public List<EducationItem> Education { get; set; } = new();
        public List<ExperienceItem> Experience { get; set; } = new();
        public string Phone { get; set; } = "";
    }
}
