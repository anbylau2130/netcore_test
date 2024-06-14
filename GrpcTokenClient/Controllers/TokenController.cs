using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;

namespace GrpcTokenClient.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TokenController:ControllerBase
    {
        public readonly TokenService.TokenServiceClient tokenClient;

        public TokenController(TokenService.TokenServiceClient tokenClient)
        {
            this.tokenClient = tokenClient;
        }


        [HttpGet]
        public IActionResult GetToken()
        {
            var result=this.tokenClient.GetToken(new Empty());
            return Ok(result);
        }
    }
}
