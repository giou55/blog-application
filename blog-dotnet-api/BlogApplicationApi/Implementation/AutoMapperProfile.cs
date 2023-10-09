using AutoMapper;
using Types.Dto;
using Types.Models;

namespace Implementation
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SuperHero, SuperHeroDto>();
            CreateMap<SuperHeroDto, SuperHero>();
            //CreateMap<SuperHeroDto, SuperHero>().ReverseMap();
        }
    }
}
