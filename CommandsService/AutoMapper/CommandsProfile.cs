using AutoMapper;
using CommandManagement.Application.Contracts.Command;
using CommandManagement.Application.Contracts.Platform;
using CommandManagement.Domain.Commands;
using CommandManagement.Domain.Platforms;
using RabbitMQLManagement.Application.Contracts;

namespace CommandsService.AutoMapper
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source -> Target

            CreateMap<Platform, PlatformViewModel>();

            CreateMap<CreateCommand, Command>();

            CreateMap<Command, CommandViewModel>();

            CreateMap<PlatformPublishedViewModel, Platform>()
                .ForMember(x => x.ExternalId, z => z.MapFrom(src => src.Id));

        }
    }
}
