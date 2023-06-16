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
        }
    }
}
