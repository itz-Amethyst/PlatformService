using AutoMapper;
using CommandManagement.Application.Contracts.Command;
using CommandManagement.Application.Contracts.Platform;
using CommandManagement.Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{

    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IMapper _mapper;
        public PlatformsController(IMapper mapper, ICommandRepository commandRepository)
        {
            _mapper = mapper;
            _commandRepository = commandRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandViewModel>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms From CommandsService <--");

            var platformsItem = _commandRepository.GetAllPlatforms();

            return Ok(_mapper.Map <IEnumerable<CommandViewModel>>(platformsItem));

        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound Post # Commands  Service <--");

            return Ok("Inbound test of from Platforms Controller");
        }
    }
}
