using System.ComponentModel.DataAnnotations;
using _0_Framework.Application.Common;

namespace PlatformManagement.Application.Contracts.Platform
{
    public class CreatePlatform
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Publisher { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Cost { get; set; }
    }
}
