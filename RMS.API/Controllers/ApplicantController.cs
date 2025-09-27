using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS.Application.DTOs;
using RMS.Application.Interfaces;
using RMS.Domain.Entities;
using System.Security.Claims;

namespace RMS.API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Applicant")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        private readonly IJobService _jobsService;

        public ApplicantController(IApplicantService applicantService, IJobService jobsService)
        {
            _applicantService = applicantService;
            _jobsService = jobsService;
        }

        [HttpPost("uploadResume")]
        public async Task<IActionResult> UploadResume([FromForm] UploadResumeRequestDto request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized();
            var allowedExtensions = new[] { ".pdf", ".docx" };
            var extension = Path.GetExtension(request.ResumeFile.FileName).ToLower();
            if (!allowedExtensions.Contains(extension))
                return BadRequest("Only PDF or DOCX files are allowed.");

            var result = await _applicantService.UploadResumeAsync(Convert.ToInt32(userId), request.ResumeFile);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpGet("jobs")]
        public async Task<ActionResult<IEnumerable<UserJobDetailDto>>> GetJobs()
        {
            var jobs = await _jobsService.GetAllJobsAsync();
            var dtos = jobs.Select(j => new UserJobDetailDto
            {
                Id = j.Id,
                Title = j.Title,
                Description = j.Description,
                PostedOn = j.PostedOn,
                TotalApplications = j.TotalApplications,
                CompanyName = j.CompanyName
            });
            return Ok(dtos);
        }
        [HttpGet("jobs/apply")]
        public async Task<IActionResult> Apply([FromQuery(Name = "job_id")] int jobId)
        {

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userTypeClaim = User.FindFirst("user_type")?.Value ?? User.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized(new { message = "Invalid user token - missing id" });

            if (string.IsNullOrEmpty(userTypeClaim))
                return Forbid();

            var jobs = await _jobsService.ApplyToJobAsync(jobId,Convert.ToInt32(userIdClaim));
            return Ok(jobs);
        }
    }
}
