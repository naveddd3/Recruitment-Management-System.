using RMS.Domain.Entities;

namespace RMS.Domain.Interfaces
{
    public interface IProfileRepository
    {
        Task<Profile?> GetByIdAsync(int id);
        Task<IEnumerable<Profile>> GetAllAsync();
        Task<Profile> AddAsync(Profile profile);
        Task<Profile> UpdateAsync(Profile profile);
        Task<Profile>  DeleteAsync(Profile profile);
    }
}
