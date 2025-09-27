using Microsoft.EntityFrameworkCore;
using RMS.Domain.Entities;
using RMS.Domain.Interfaces;
using RMS.Infrastructure.Data;

namespace RMS.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _context.Users.Include(u => u.Profile).FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
        public async Task<User?> GetByEmailAsync(string email) =>
            await _context.Users.Include(u => u.Profile).FirstOrDefaultAsync(x => x.Email == email);

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _context.Users.Where(u => u.Id != 1).Include(u => u.Profile).ToListAsync();

        public async Task<User?> AddAsync(User user)
        {
            var userRes = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return userRes.Entity;
        }

        public async Task<User?> UpdateAsync(User user)
        {
            var userRes = _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return userRes.Entity;
        }

        public async Task<User?> DeleteAsync(User user)
        {
            var userRes = _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return userRes.Entity;
        }

        public async Task<Profile?> UploadResumeProfile(Profile profile)
        {
            var userRes = await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();
            return userRes.Entity;
        }
    }
}
