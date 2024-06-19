using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Polly.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult TestRely(int id)
        {
            var randomNumber=Random.Shared.Next(1,100);
            if (randomNumber <id) {
                Console.WriteLine("请求成功 200");
                return Ok("请求成功");
            }
            Console.WriteLine("请求失败 400");
           return Ok("请求失败");
        }



        [HttpGet("{id}")]
        public ActionResult TestBreaker(int id)
        {
            var randomNumber = Random.Shared.Next(1, 100);
            if (randomNumber < id)
            {
                Console.WriteLine("请求成功 200");
                return Ok("请求成功");
            }
            Console.WriteLine("请求失败 400");
            return Ok("请求失败");
        }
    }
}
