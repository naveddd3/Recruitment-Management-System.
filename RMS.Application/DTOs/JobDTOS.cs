using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Application.DTOs
{
    public class JobCreateDto
    {
        [Required, MaxLength(200)]
        public string Title { get; set; } = "";

        [Required, MaxLength(1000)]
        public string Description { get; set; } = "";

        [Required, MaxLength(200)]
        public string CompanyName { get; set; } = "";
    }

    public class JobDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public DateTime PostedOn { get; set; }
        public int TotalApplications { get; set; }
        public List<ApplicantDto> Applicants { get; set; } = new();
    }

    public class UserJobDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public DateTime PostedOn { get; set; }
        public int TotalApplications { get; set; }
    }

    public class ApplicantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
    }

}
