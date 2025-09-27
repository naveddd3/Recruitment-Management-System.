using Microsoft.EntityFrameworkCore;
using RMS.Domain.Entities;
using RMS.Domain.Interfaces;
using RMS.Infrastructure.Data;

namespace RMS.Infrastructure.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly AppDbContext _context;

        public ProfileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Profile?> GetByIdAsync(int id) =>
            await _context.Profiles.Include(p => p.User).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Profile>> GetAllAsync() =>
            await _context.Profiles.Include(p => p.User).ToListAsync();

        public async Task<Profile> AddAsync(Profile profile)
        {
            var response = await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<Profile> UpdateAsync(Profile profile)
        {
            var response = _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<Profile> DeleteAsync(Profile profile)
        {
            var response = _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
            return response.Entity;
        }
    }
}
