using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreNacos.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NacosController : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("test1");
        }
    }
}
