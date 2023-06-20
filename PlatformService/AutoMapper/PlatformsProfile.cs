using AutoMapper;
using PlatformManagement.Application.Contracts.Platform;
using PlatformManagement.Domain;
using RabbitMQLManagement.Application.Contracts;

namespace PlatformService.AutoMapper
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            CreateMap<Platform, PlatformViewModel>();
            CreateMap<CreatePlatform, Platform>();
            CreateMap<PlatformViewModel, PlatformPublishedViewModel>();
            CreateMap<Platform, GrpcPlatformModel>()
                .ForMember(x => x.PlatformId, z => z.MapFrom(src => src.Id))
                .ForMember(x => x.Name, z => z.MapFrom(src => src.Name))
                .ForMember(x => x.Publisher, z => z.MapFrom(src => src.Publisher));
        }
    }
}
