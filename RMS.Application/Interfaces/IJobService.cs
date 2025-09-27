using RMS.Application.Common;
using RMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Application.Interfaces
{
    public interface IJobService
    {
        Task<Job?> GetJobByIdAsync(int id);
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task<Job?> CreateJobAsync(Job job);
        Task<Job?> UpdateJobAsync(Job job);
        Task<Job?> DeleteJobAsync(int id);
        Task<Response<string>> ApplyToJobAsync(int jobId, int applicantId, string resumeAddress = null);
    }
}
