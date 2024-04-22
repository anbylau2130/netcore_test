using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FilterController : ControllerBase
    {

        [HttpGet]
        public double Div(double a,double b)
        {
            // throw new Exception();
            return a / b;
        }
    }
}
