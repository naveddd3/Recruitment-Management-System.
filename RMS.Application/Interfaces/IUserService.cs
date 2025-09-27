using RMS.Application.DTOs;
using RMS.Domain.Entities;

namespace RMS.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllApplicantsAsync();
        Task<ApplicantDetailDto?> GetApplicantByIdAsync(int applicantId);
    }
}
