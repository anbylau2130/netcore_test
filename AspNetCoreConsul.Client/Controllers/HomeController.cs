using Consul;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AspNetCoreConsul.Client.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IConsulClient consulClient;

        public HomeController(IConsulClient consulClient)
        {
            this.consulClient = consulClient;
        }
        [HttpGet]

        public async Task<IActionResult> TestConsul()
        {
            var services = (await consulClient.Catalog.Service("AspNetCoreConsul.Service")).Response;
            var instance = services[Random.Shared.Next(services.Length)];
            using HttpClient client = new HttpClient();
            var json = await client.GetStringAsync($"http://{instance.ServiceAddress}:{instance.ServicePort}/Product/GetProduct");
            var result = JsonConvert.DeserializeObject<dynamic>(json);
            return Ok($"服务B结果：{result}；服务A测试成功");
        }
    }
}
