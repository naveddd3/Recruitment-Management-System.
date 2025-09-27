using Microsoft.EntityFrameworkCore;
using RMS.Domain.Entities;
using RMS.Domain.Interfaces;
using RMS.Infrastructure.Data;

namespace RMS.Infrastructure.Repository
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly AppDbContext _context;

        public ResumeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Resume> AddAsync(Resume resume)
        {
            var response = await _context.Resumes.AddAsync(resume);
            await _context.SaveChangesAsync();
            return response.Entity;

        }
        public async Task<Resume?> GetByIdAsync(int id)
        {
            return await _context.Resumes.FindAsync(id);
        }
        public async Task<IEnumerable<Resume>> GetByApplicantIdAsync(int applicantId)
        {
            return await _context.Resumes
                .Where(r => r.ApplicantId == applicantId)
                .OrderByDescending(r => r.UploadedOn)
                .ToListAsync();
        }
    }
}
