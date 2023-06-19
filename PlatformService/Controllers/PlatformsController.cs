using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformManagement.Application.Contracts.Platform;
using PlatformManagement.Domain;
using PlatformManagement.Infrastructure.Services.SyncDataServices.http;
using RabbitMQLManagement.Application.Contracts;
using RabbitMQLManagement.Domain;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        //private readonly ILogger _logger;
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;
        private readonly IMessageBusClient _messageBusClient;

        public PlatformsController(IPlatformRepository platformRepository, IMapper mapper, ICommandDataClient commandDataClient, IMessageBusClient messageBusClient)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
            _messageBusClient = messageBusClient;
        }


        [HttpGet]
        public ActionResult<IEnumerable<PlatformViewModel>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms");

            var platformItem = _platformRepository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformViewModel>>(platformItem));
        }

        [HttpGet("{id}" , Name = "GetPlatformById")]
        public ActionResult<PlatformViewModel> GetPlatformById(int id)
        {
            var platformData = _platformRepository.GetById(id);

            if (platformData != null)
            {
                return Ok(_mapper.Map<PlatformViewModel>(platformData));
            }

            return NotFound();

        }

        [HttpPost]
        public async Task<ActionResult<PlatformViewModel>> CreatePlatform(CreatePlatform command)
        {

            _platformRepository.CreatePlatform(command);

            var platformData = _mapper.Map<Platform>(command);

            var platformViewModel = _mapper.Map<PlatformViewModel>(platformData);

            // Send Sync message

            try
            {
               await _commandDataClient.SendPlatformToCommand(platformViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine($"--> Could not send synchronously {e.Message}");
            }

            // Send Async message

            try
            {
                var platformPublishedDto = _mapper.Map<PlatformPublishedViewModel>(platformViewModel);
                platformPublishedDto.Event = "Platform_Published";
                _messageBusClient.PublishNewPlatform(platformPublishedDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"--> Could not send Asynchronously {e.Message}");
            }

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformData.Id }, platformData);
        }
    }
}
