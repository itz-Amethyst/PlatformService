using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformManagement.Application.Contracts.Platform;
using PlatformManagement.Domain;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        //private readonly ILogger _logger;
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public PlatformController(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
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
        public ActionResult<PlatformViewModel> CreatePlatform(CreatePlatform command)
        {
            //var platformModel = _mapper.Map<Platform>(command);

            _platformRepository.CreatePlatform(command);

            var platformData = _mapper.Map<Platform>(command);

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformData.Id }, platformData);
        }
    }
}
