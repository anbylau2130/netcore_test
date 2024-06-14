using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreNacos.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NacosController : ControllerBase
    {
        [HttpGet]
        public  async Task<IActionResult> Get()
        {
            return Ok("test2");
        }
    }
}
