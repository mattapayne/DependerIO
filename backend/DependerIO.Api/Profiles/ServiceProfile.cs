using AutoMapper;

namespace DependerIO.Api.Profiles {
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Models.Service, DTO.Service>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}