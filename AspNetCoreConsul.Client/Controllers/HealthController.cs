using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreConsul.Client.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public string Check()
        {
            Console.WriteLine("Client心跳检测");
            return $"{DateTime.Now}";
        }
    }
}
