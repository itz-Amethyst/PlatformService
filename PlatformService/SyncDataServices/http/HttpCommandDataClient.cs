using System.Text;
using System.Text.Json;
using PlatformManagement.Application.Contracts.Platform;

namespace PlatformService.SyncDataServices.http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendPlatformToCommand(PlatformViewModel command)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
            "application/json");

            //? Goes to appsettings.json and pick CommandService url
            //Note: remember to add .value after getsection to gets that value 
            var response = await _httpClient.PostAsync($"{_configuration.GetSection("CommandService").Value}/api/c/Platforms", httpContent);

            //! Short of if and else
            //Console.WriteLine(response.IsSuccessStatusCode
            //    ? "--> Sync Post to CommandService was ok ! <--"
            //    : "--> Sync Post to CommandService was Not OK ! <--");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync Post to CommandService was ok ! <--");
            }
            else
            {
                Console.WriteLine("--> Sync Post to CommandService was Not OK ! <--");
            }
        }
    }
}
