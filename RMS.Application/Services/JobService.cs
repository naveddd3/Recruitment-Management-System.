using RMS.Application.Common;
using RMS.Application.Interfaces;
using RMS.Domain.Entities;
using RMS.Domain.Interfaces;

namespace RMS.Application.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<Job?> GetJobByIdAsync(int id)
        {
            return await _jobRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _jobRepository.GetAllAsync();
        }

        public async Task<Job?> CreateJobAsync(Job job)
        {
            return await _jobRepository.AddAsync(job); 
        }

        public async Task<Job?> UpdateJobAsync(Job job)
        {
            return await _jobRepository.UpdateAsync(job);
        }

        public async Task<Job?> DeleteJobAsync(int id)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null) return null;

            return await _jobRepository.DeleteAsync(job);
        }

        public async Task<Response<string>> ApplyToJobAsync(int jobId, int applicantId, string resumeAddress = null)
        {
            var response = await _jobRepository.ApplyToJobAsync(jobId, applicantId, resumeAddress);
            if (response != null)
            {
                return new Response<string>
                {
                    IsSuccess = true,
                    Message = "Applied Successfully!"
                };
            }
            return new Response<string>
            {
                IsSuccess = false,
                Message = "Job not found Or You Already Applied!"
            };
        }
    }
}
