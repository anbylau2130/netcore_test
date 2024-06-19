using ASPNETCORE.Polly.Polly;
using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;

namespace ASPNETCORE.Polly.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly ClientPolly<object> _clientPolly;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ClientPolly<object> clientPolly, IHttpClientFactory httpClientFactory)
        {
            _clientPolly = clientPolly;
            _httpClientFactory = httpClientFactory;
        }


        /// <summary>
        /// 重试
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> TestRely(int id)
        {
           using var httpClient = _httpClientFactory.CreateClient();
            var response = await _clientPolly.RetryPolicy
                .ExecuteAsync(() => httpClient.GetAsync($"http://localhost:5159/Home/TestRely/{id}"));
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("请求成功");
            }
            else
            {
                Console.WriteLine("请求失败");
            }

            return Content("请求完毕");
        }



        /// <summary>
        /// 熔断
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> TestBreaker(int id)
        {
            try
            {
               using var httpClient = _httpClientFactory.CreateClient();
                var response = await _clientPolly.CircuitBreakerPolicy
                    .ExecuteAsync(() => httpClient.GetAsync($"http://localhost:5159/Home/TestBreaker/{id}"));
                return Ok(response);
            }
            catch (BrokenCircuitException e)
            {
                Console.WriteLine($"熔断异常:{e.Message}");
                throw e;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"异常信息:{ex.Message}");
                throw ex;
            }
        }
    }
}
