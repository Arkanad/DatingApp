using System;
using System.Linq;
using API.Entites;
using AutoMapper;

namespace API;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles(){
        CreateMap<AppUser, MemberDto>()
        .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
        .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
        CreateMap<Photo, PhotoDto>();
    }
}
