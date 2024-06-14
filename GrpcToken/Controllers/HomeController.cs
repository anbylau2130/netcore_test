using GrpcToken.Apis;
using Microsoft.AspNetCore.Mvc;

namespace GrpcToken.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public HomeController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet]
        public IActionResult GetToken()
        {
            var result = this._tokenService.GetToken();
            return Ok(result);
        }
    }
}
