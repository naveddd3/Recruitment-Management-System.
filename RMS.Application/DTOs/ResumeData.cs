using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Application.DTOs
{
    public class ResumeData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<string> Skills { get; set; }
        public List<EducationItem> Education { get; set; }
        public List<ExperienceItem> Experience { get; set; }
    }

    public class EducationItem
    {
        public string Name { get; set; }
        public List<string> Dates { get; set; } = new();
    }

    public class ExperienceItem
    {
        public string Title { get; set; }
        public List<string> Dates { get; set; } = new();
        public string Location { get; set; }
        public string Organization { get; set; }
    }


}
