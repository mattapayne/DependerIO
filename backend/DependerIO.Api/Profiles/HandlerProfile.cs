using AutoMapper;

namespace DependerIO.Api.Profiles {
    public class HandlerProfile : Profile
    {
        public HandlerProfile()
        {
            CreateMap<Models.Handler, DTO.Handler>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.ServiceId.ToString()))
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Name));
        }
    }
}