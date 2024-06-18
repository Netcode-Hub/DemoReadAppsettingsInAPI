using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DemoReadAppsettingsInAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController(IConfiguration configuration, IOptions<Connections> options) : ControllerBase
    {
        private readonly Connections Connections = options.Value;
        [HttpGet("v1")]
        public IActionResult Get()
        {
            string blazorCon = configuration["Connections:Blazor"]!;
            string ApiCon = configuration["Connections:Api"]!;
            string username = configuration["Connections:Username"]!;
            string password = configuration["Connections:Password"]!;
            string[] list = [$"Blazor Con: {blazorCon}", $"API Con: {ApiCon}", $"Username:{username}", $"Password: {password}"];
            return Ok(list);
        }
        [HttpGet("v2")]
        public IActionResult GetConfigurations5()
        {
            string blazorCon = Connections.Blazor!;
            string ApiCon = Connections.Api!;
            string username = Connections.Username!;
            string password = Connections.Password!;
            string[] list = [blazorCon, ApiCon, username, password];
            return Ok(list);
        }
    }
}
