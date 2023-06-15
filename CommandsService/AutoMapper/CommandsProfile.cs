using AutoMapper;
using CommandManagement.Application.Contracts.Command;
using CommandManagement.Application.Contracts.Platform;
using CommandManagement.Domain.Commands;
using CommandManagement.Domain.Platforms;

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

        }
    }
}
