using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Znamenitost, ZnamenitostiToReturnDto>()
            .ForMember(d => d.Veomaznamenito, o => o.MapFrom(s => s.Veomaznamenito.Naziv))
            .ForMember(d => d.Nezaobilazno, o => o.MapFrom(s => s.Nezaobilazno.Naziv))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<ZnamenitostiResolver>());
        }
    }
}