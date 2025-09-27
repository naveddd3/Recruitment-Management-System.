using AutoMapper;
using RMS.Application.Common;
using RMS.Application.DTOs;
using RMS.Application.Interfaces;
using RMS.Domain.Entities;
using RMS.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace RMS.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository, IJwtService jwtService, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Signup(SignupRequestDto request, string password)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
                return Response<string>.Fail("User already exists");

            var user = _mapper.Map<User>(request);
            user.PasswordHash = HashPassword(password);
            await _userRepository.AddAsync(user);

            return Response<string>.Success("", "User registered successfully");
        }
        public async Task<Response<string>> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return Response<string>.Fail("Invalid email or password");

            var token = _jwtService.GenerateToken(user);
            return Response<string>.Success(token, "Login successful");
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}
