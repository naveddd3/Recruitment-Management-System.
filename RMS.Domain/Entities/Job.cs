using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Domain.Entities
{
    public class Job
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = "";

        [Required, MaxLength(1000)]
        public string Description { get; set; } = "";

        public DateTime PostedOn { get; set; } = DateTime.UtcNow;

        [Range(0, int.MaxValue)]
        public int TotalApplications { get; set; }

        [Required, MaxLength(200)]
        public string CompanyName { get; set; } = "";

        public int PostedById { get; set; }
        public User? PostedBy { get; set; }


        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }
}
