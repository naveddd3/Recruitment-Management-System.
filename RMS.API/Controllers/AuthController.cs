using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RMS.Application.Common;
using RMS.Application.DTOs;
using RMS.Application.Interfaces;
using RMS.Domain.Entities;

namespace RMS.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public async Task<ActionResult<Response<string>>> Signup([FromBody] SignupRequestDto request)
        {
            var result = await _authService.Signup(request, request.Password);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Response<string>>> Login([FromBody] LoginRequestDTO request)
        {
            var result = await _authService.Login(request.Email, request.Password);
            return Ok(result);
        }
    }
}
