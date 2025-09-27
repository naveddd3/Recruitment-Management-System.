using RMS.Domain.Entities;

namespace RMS.Domain.Interfaces
{
    public interface IJobRepository
    {
        Task<Job?> GetByIdAsync(int id);
        Task<IEnumerable<Job>> GetAllAsync();
        Task<Job?> AddAsync(Job job);
        Task<Job?> UpdateAsync(Job job);
        Task<Job?> DeleteAsync(Job job);
        Task<JobApplication> ApplyToJobAsync(int jobId, int applicantId, string resumeAddress = null);
    }
}
