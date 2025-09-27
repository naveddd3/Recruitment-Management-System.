using RMS.Application.Common;
using RMS.Application.DTOs;
using RMS.Domain.Entities;

namespace RMS.Application.Interfaces
{
    public interface IAuthService
    {
        Task<Response<string>> Signup(SignupRequestDto user, string password);
        Task<Response<string>> Login(string email, string password);
    }
}
