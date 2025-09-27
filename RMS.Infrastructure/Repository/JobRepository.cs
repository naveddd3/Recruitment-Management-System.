using Microsoft.EntityFrameworkCore;
using RMS.Application.Common;
using RMS.Domain.Entities;
using RMS.Domain.Interfaces;
using RMS.Infrastructure.Data;

namespace RMS.Infrastructure.Repository
{
    public class JobRepository: IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Job?> GetByIdAsync(int id) =>
                                await _context.Jobs
                                    .Include(j => j.PostedBy)
                                    .Include(j => j.Applications).ThenInclude(a => a.Applicant)
                                    .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Job>> GetAllAsync() =>
            await _context.Jobs.Include(j => j.PostedBy).OrderByDescending(j => j.PostedOn).ToListAsync();

        public async Task<Job?> AddAsync(Job job)
        {
            var response = await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<Job?> UpdateAsync(Job job)
        {
           var response =  _context.Jobs.Update(job);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<Job?> DeleteAsync(Job job)
        {
            var response = _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return response.Entity;
        }
        public async Task<JobApplication> ApplyToJobAsync(int jobId, int applicantId, string resumeAddress = null)
        {
            var job = await _context.Jobs.FindAsync(jobId);
            if (job == null)
            {
                return null;
            }
            var existing = await _context.JobApplications.FirstOrDefaultAsync(a => a.JobId == jobId && a.ApplicantId == applicantId);
            if (existing != null)
                return null;
            var application = new JobApplication
            {
                JobId = jobId,
                ApplicantId = applicantId,
                AppliedOn = DateTime.UtcNow
            };
           var response= await _context.JobApplications.AddAsync(application);
            if (response != null)
            {
                job.TotalApplications += 1;
                _context.Jobs.Update(job);
            }
            await _context.SaveChangesAsync();
            return response.Entity;

        }
    }
}
