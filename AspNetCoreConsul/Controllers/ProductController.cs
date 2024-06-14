using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreConsul.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(new { ProductId = 1 });
        }
    }
}
