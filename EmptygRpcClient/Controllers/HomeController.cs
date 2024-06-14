using EmptygRpcServer;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace EmptygRpcClient.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly UserService.UserServiceClient _client;
        public HomeController(UserService.UserServiceClient client)
        {
            _client = client;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userResponse= _client.GetUserInfo(new UserRequest());
            return Ok(userResponse.UserList);
        }
    }
}
