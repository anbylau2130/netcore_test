using Microsoft.AspNetCore.Mvc;

namespace GrpcTokenClient.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        public readonly UserService.UserServiceClient userServiceClient;

        public UserController(UserService.UserServiceClient userServiceClient)
        {
            this.userServiceClient = userServiceClient;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            var response=this.userServiceClient.GetUser(new UserRequest());
            return Ok(response);
        }
    }
}
