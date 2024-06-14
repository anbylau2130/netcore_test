using Microsoft.AspNetCore.Mvc;

namespace NacosConfigCenter.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {

        private readonly IConfiguration configuration;

        public TestController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public ActionResult GetNacosConfig()
        {
            var conn=configuration.GetConnectionString("SQLSERVER");

            var otherConfig = configuration["ServerName"];
            var otherConfig2= configuration["Details:ID"];

            return  Ok(new { conn= conn, otherConfig , otherConfig2 });

        }
    }
}
