using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreConsul.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public string Check()
        {
            Console.WriteLine("Service心跳检测");
            return $"{DateTime.Now}";
        }
    }
}
