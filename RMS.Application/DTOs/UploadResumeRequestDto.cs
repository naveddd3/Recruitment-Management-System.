using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RMS.Application.DTOs
{
    public class UploadResumeRequestDto
    {
        [Required]
        public IFormFile ResumeFile { get; set; }
    }
}
