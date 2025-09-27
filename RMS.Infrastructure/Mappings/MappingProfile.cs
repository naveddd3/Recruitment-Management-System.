using Newtonsoft.Json;
using RMS.Application.DTOs;
using RMS.Domain.Entities;

namespace RMS.Infrastructure.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<SignupRequestDto, User>();
            CreateMap<JobCreateDto, Job>();
            CreateMap<Job, JobDetailDto>();
            CreateMap<User, UserDto>();
            CreateMap<User, ApplicantDto>();

            CreateMap<User, ApplicantDetailDto>()
            .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile));

            CreateMap<Profile, ProfileDto>()
            .ForMember(dest => dest.Skills, opt => opt.Ignore())       // Ignore mapping
            .ForMember(dest => dest.Education, opt => opt.Ignore())    // Ignore mapping
            .ForMember(dest => dest.Experience, opt => opt.Ignore());  // Ignore mapping
        }
    }
}
