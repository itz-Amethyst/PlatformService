using AutoMapper;
using CommandManagement.Application.Contracts.Command;
using CommandManagement.Domain.Commands;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace CommandsService.Controllers
{
    [Route("api/c/platforms/{platformId}/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepository commandRepository, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandViewModel>> GetCommandsForPlatform(int platformId)
        {
            Console.WriteLine($"--> Hit GetCommandsForPlatform: {platformId} <--");

            if (!_commandRepository.Exists(x => x.PlatformId == platformId))
            {
                return NotFound();
            }

            var commands = _commandRepository.GetCommandsForPlatform(platformId);

            return Ok(_mapper.Map<IEnumerable<CommandViewModel>>(commands));
        }

        [HttpGet("{commandId}", Name = "GetCommandForPlatform")]
        public ActionResult<CommandViewModel> GetCommandForPlatform(int platformId , int commandId)
        {
            Console.WriteLine($"--> Hit GetCommandForPlatform: {platformId} / {commandId} <--");

            if (!_commandRepository.Exists(x => x.PlatformId == platformId))
            {
                return NotFound();
            }

            var command = _commandRepository.GetCommand(platformId, commandId);

            if (command == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CommandViewModel>(command));
        }

        [HttpPost]
        public ActionResult<CommandViewModel> CreateCommandForPlatform(int platformId , CreateCommand commandDto)
        {
            Console.WriteLine($"--> Hit CreateCommandForPlatform: {platformId} <--");

            if (_commandRepository.Exists(x => x.PlatformId == platformId))
            {
                return NotFound();
            }

            //var command = _mapper.Map<Command>(commandDto);

            _commandRepository.CreateCommand(platformId , commandDto);

            return CreatedAtRoute(nameof(GetCommandForPlatform),
                new { platformId = platformId, commandId = commandDto.Id }, commandDto);
        }
    }
}
