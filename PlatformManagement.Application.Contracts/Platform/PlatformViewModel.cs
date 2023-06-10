using _0_Framework.Application.Common;
using System.ComponentModel.DataAnnotations;

namespace PlatformManagement.Application.Contracts.Platform
{
    public class PlatformViewModel
    {
        public int Id { get; set; }

        public string CreationDate { get; set; }

        public string Name { get; set; }

        public string Publisher { get; set; }

        public string Cost { get; set; }
    }
}
