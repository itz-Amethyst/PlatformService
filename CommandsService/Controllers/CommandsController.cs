using AutoMapper;
using CommandManagement.Application.Contracts.Command;
using CommandManagement.Domain.Commands;
using Microsoft.AspNetCore.Mvc;

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
    }
}
