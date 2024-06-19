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
        /// ����
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
                Console.WriteLine("����ɹ�");
            }
            else
            {
                Console.WriteLine("����ʧ��");
            }

            return Content("�������");
        }



        /// <summary>
        /// �۶�
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
                Console.WriteLine($"�۶��쳣:{e.Message}");
                throw e;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"�쳣��Ϣ:{ex.Message}");
                throw ex;
            }
        }
    }
}
