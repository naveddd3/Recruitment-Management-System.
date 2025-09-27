using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RMS.Application.Common;
using RMS.Application.DTOs;
using RMS.Application.Interfaces;
using RMS.Domain.Entities;
using RMS.Domain.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RMS.Application.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IThirdPartyResumeProcessor _resumeProcessor;
        private readonly IUserRepository _userRepository;

        public ApplicantService(IResumeRepository resumeRepository, IThirdPartyResumeProcessor resumeProcessor, IUserRepository userRepository)
        {
            _resumeRepository = resumeRepository;
            _resumeProcessor = resumeProcessor;
            _userRepository = userRepository;
        }

        public async Task<Response<string>> UploadResumeAsync(int applicantId, IFormFile resumeFile)
        {
            var filePath = Path.Combine("Uploads", Guid.NewGuid() + Path.GetExtension(resumeFile.FileName));
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await resumeFile.CopyToAsync(stream);
            }
            var processedData = await _resumeProcessor.ProcessResumeAsync(resumeFile);
            
            var profile = new Profile
            {
                ResumeFileAddress = filePath,
                Skills = JsonConvert.SerializeObject(processedData.Skills),
                Education = JsonConvert.SerializeObject(processedData.Education),
                Experience = JsonConvert.SerializeObject(processedData.Experience),
                Phone = processedData.Phone,
                UserId = applicantId
            };
            var response = await _userRepository.UploadResumeProfile(profile);
            if (response!= null)
            {

                return new Response<string>
                {
                    IsSuccess = true,
                    Message = "Resume uploaded and processed successfully"
                };
            }

            return new Response<string>
            {
                IsSuccess = false,
                Message = "Resume uploaded failed"
            };
        }
    }
}
