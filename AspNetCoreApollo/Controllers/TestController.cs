using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApollo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
       private readonly IConfiguration _configuration;

        public TestController(IConfiguration configuration)
        {
            this._configuration= configuration;
        }
        

        [HttpPost]
        public IActionResult GetNewTest()
        {
            var result=this._configuration.GetConnectionString("sqlserver");
            return Ok(result);
        }
    }
}
