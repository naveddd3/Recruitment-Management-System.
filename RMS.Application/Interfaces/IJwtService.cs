using RMS.Domain.Entities;

namespace RMS.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
