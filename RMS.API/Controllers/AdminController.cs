using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS.Application.Common;
using RMS.Application.DTOs;
using RMS.Application.Interfaces;
using RMS.Domain.Entities;

namespace RMS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AdminController(IJobService jobService, IMapper mapper,IUserService userService)
        {
            _jobService = jobService;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("job")]
        public async Task<IActionResult> CreateJob([FromBody] JobCreateDto dto)
        {
            var userId = 1; //int.Parse(User.FindFirst("id")!.Value);

            var job = _mapper.Map<Job>(dto);
            job.PostedById = userId;
            job.PostedOn = DateTime.UtcNow;

            var createdJob = await _jobService.CreateJobAsync(job);
            if (createdJob != null)
            {
                return Ok(new Response<string>
                {
                    IsSuccess = true,
                    Message = "Job Created Successfulyy"
                });
            }
            return Ok(new Response<string>
            {
                IsSuccess = false,
                Message = "Job Creation failed"
            });
        }

        [HttpGet("job/{jobId}")]
        public async Task<IActionResult> GetJob(int jobId)
        {
            var job = await _jobService.GetJobByIdAsync(jobId);
            if (job == null) return NotFound();

            var jobDto = _mapper.Map<JobDetailDto>(job);
            jobDto.Applicants = job.Applications.Select(a => _mapper.Map<ApplicantDto>(a.Applicant)).ToList();

            return Ok(jobDto);
        }

        [HttpGet("applicants")]
        public async Task<IActionResult> GetAllApplicants()
        {
            var users = await _userService.GetAllApplicantsAsync();
            var userDtos = _mapper.Map<List<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet("applicant/{applicantId}")]
        public async Task<IActionResult> GetApplicant(int applicantId)
        {
            var user = await _userService.GetApplicantByIdAsync(applicantId);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
