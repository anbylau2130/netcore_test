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
                Console.WriteLine("����ɹ� 200");
                return Ok("����ɹ�");
            }
            Console.WriteLine("����ʧ�� 400");
           return Ok("����ʧ��");
        }



        [HttpGet("{id}")]
        public ActionResult TestBreaker(int id)
        {
            var randomNumber = Random.Shared.Next(1, 100);
            if (randomNumber < id)
            {
                Console.WriteLine("����ɹ� 200");
                return Ok("����ɹ�");
            }
            Console.WriteLine("����ʧ�� 400");
            return Ok("����ʧ��");
        }
    }
}
