using Microsoft.AspNetCore.Mvc;
using PlatformManagement.Application.Contracts.Platform;
using PlatformManagement.Domain;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPlatformRepository _platformRepository;

        public PlatformController(IPlatformRepository platformRepository, ILogger logger)
        {
            _platformRepository = platformRepository;
            _logger = logger;
        }


        [HttpGet]
        public ActionResult<IEnumerable<PlatformViewModel>> GetPlatforms()
        {
            _logger.LogWarning("--> Getting Platforms <--");
            //Console.WriteLine("--> Getting Platforms");

            var platformItem = _platformRepository.GetAllPlatforms();
        }
    }
}
