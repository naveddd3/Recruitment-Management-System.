using Microsoft.AspNetCore.Http;
using RMS.Application.DTOs;

namespace RMS.Application.Interfaces
{
    public interface IThirdPartyResumeProcessor
    {
        Task<ResumeData> ProcessResumeAsync(IFormFile resumeFile);
    }
}
