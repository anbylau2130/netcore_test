using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nacos.V2;
using Nacos.V2.Config;
using Nacos.V2.Naming;

namespace AspNetCoreNacos.Client.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly INacosNamingService _namingService;

        public UserController(INacosNamingService namingService)
        {
            _namingService = namingService;
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var instance = await _namingService.SelectOneHealthyInstance("App1");
            var host = $"{instance.Ip}:{instance.Port}";
            var baseUrl = instance.Metadata.TryGetValue("secure", out _)
                ? $"https://{host}"
                : $"http://{host}";
            if (string.IsNullOrEmpty(baseUrl))
            {
                return Ok("empty");
            }
            var url = $"{baseUrl}/Nacos/Get";
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetAsync(url);
                return Ok(await result.Content.ReadAsStringAsync());
            }
        }
    }
}
