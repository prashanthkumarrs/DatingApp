using AutoMapper;
using API.Entities;
using API.DTOs;
using System.Linq;
using API.Extensions;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
           public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
            .ForMember(dest => dest.PhotoUrl, opt=> opt.MapFrom
            (sourceMember=>sourceMember.Photos.FirstOrDefault(x=>x.IsMain).Url))
            .ForMember(dest=> dest.Age, opt =>opt.MapFrom(src => src.DateofBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>();           
        }
    }
}