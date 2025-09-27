using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Domain.Entities
{
    public class Applicant
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public User User { get; set; } = null!;
        //public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}
