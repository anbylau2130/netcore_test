using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreConsulConfig.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
    

        private readonly IConfiguration configuration;

        public TestController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result=this.configuration.GetConnectionString("mysql");
            return Ok(result);
        }
    }
}
