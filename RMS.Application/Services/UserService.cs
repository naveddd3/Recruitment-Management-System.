using AutoMapper;
using Newtonsoft.Json;
using RMS.Application.DTOs;
using RMS.Application.Interfaces;
using RMS.Domain.Entities;
using RMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAllApplicantsAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<ApplicantDetailDto?> GetApplicantByIdAsync(int applicantId)
        {
            var user = await _userRepository.GetByIdAsync(applicantId);
            if (user == null)
                return null;
            var applicantDto = _mapper.Map<ApplicantDetailDto>(user);
            if (user.Profile != null)
            {
                applicantDto.Profile.Skills = string.IsNullOrEmpty(user.Profile?.Skills)
                ? new List<string>()
                : JsonConvert.DeserializeObject<List<string>>(user.Profile.Skills)!;

                applicantDto.Profile.Education = string.IsNullOrEmpty(user.Profile?.Education)
                    ? new List<EducationItem>()
                    : JsonConvert.DeserializeObject<List<EducationItem>>(user.Profile.Education)!;

                applicantDto.Profile.Experience = string.IsNullOrEmpty(user.Profile?.Experience)
                    ? new List<ExperienceItem>()
                    : JsonConvert.DeserializeObject<List<ExperienceItem>>(user.Profile.Experience)!;
            }
            return applicantDto;
        }
    }
}
