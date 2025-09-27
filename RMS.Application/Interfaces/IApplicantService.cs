using Microsoft.AspNetCore.Http;
using RMS.Application.Common;

namespace RMS.Application.Interfaces
{
    public interface IApplicantService
    {
        Task<Response<string>> UploadResumeAsync(int applicantId, IFormFile resumeFile);
    }
}
