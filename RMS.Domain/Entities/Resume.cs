using System.ComponentModel.DataAnnotations;

namespace RMS.Domain.Entities
{
    public class Resume
    {
        public int Id { get; set; }

        [Required]
        public int ApplicantId { get; set; }

        [Required]
        public string ExtractedData { get; set; }
        [Required]
        public string FilePath { get; set; }

        [Required]
        public DateTime UploadedOn { get; set; }
    }
}
