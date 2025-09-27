using RMS.Domain.Entities;

namespace RMS.Domain.Interfaces
{
    public interface IResumeRepository
    {
        Task<Resume> AddAsync(Resume resume);
        Task<Resume?> GetByIdAsync(int id);
        Task<IEnumerable<Resume>> GetByApplicantIdAsync(int applicantId);
    }
}
