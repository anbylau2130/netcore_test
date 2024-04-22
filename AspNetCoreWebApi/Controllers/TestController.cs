using System.Security.Cryptography;
using System.Text.Json;
using System.Xml.Linq;
using AspNetCoreWebApi.Model;
using AspNetCoreWebApi.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace AspNetCoreWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet()]
        public Person GetPerson()
        {
            return null;
        }

        [HttpPost]
        public string[] AddPerson(Person person)
        {
            System.IO.File.WriteAllText(person.Name + ".txt", person.Age.ToString());
            return new string[] { "OK", person.Name };
        }


        [HttpGet("Person/GetPerson/{name}/{age}")]
        public Person GetPerson(string name, int age)
        {
            return new Person(1, name, age);
        }


        // FromRoute从URL中获取参数
        [HttpGet("Person/GetPersonByName/{Name}")]
        public Person GetPerson([FromRoute(Name = "Name")] string name)
        {
            return new Person(1, name, 18);
        }

        // FromHeader 从http header中获取参数
        [HttpGet("GetToken/{id}")]
        public string GetToken([FromRoute(Name = "id")] int id, [FromHeader(Name = "webapi_token")] string token)
        {
            return token;
        }

        //1.使用依赖注入
        private readonly Calculator calculator;
        private readonly IMemoryCache memoryCache;

        public TestController(Calculator calculator, IMemoryCache memoryCache)
        {
            this.calculator = calculator;
            this.memoryCache = memoryCache;
        }
        [HttpPost("Add/{a}/{b}")]
        public int Add(int a, int b)
        {
            return calculator.Add(a, b);
        }


        // 只在该方法使用的时候，FromServices标记的参数才进行注入
        [HttpPost("Plus/{a}/{b}")]
        public int Plus([FromServices] Calculator calculator, int a, int b)
        {
            return calculator.Plus(a, b);
        }

        //客户端缓存 【20秒内的返回数据会从缓存中读取】
        [ResponseCache(Duration = 20)]
        [HttpGet]
        public DateTime Now()
        {
            return DateTime.Now;
        }


        /// <summary>
        /// 使用MemoryCache
        /// 1，注册 builder.Services.AddMemoryCache();
        /// 2，private readonly IMemoryCache memoryCache;
        /// 3, 构造函数中进行注入 public TestController(Calculator calculator, IMemoryCache memoryCache)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("UseMemoryCache")]
        public async Task<Person> UseMemoryCache(long id)
        {
            var name = RandomChineseName.GenerateName();
            Person person = await memoryCache.GetOrCreateAsync<Person>($"Person{id}", async (e) =>
            {
                //设置缓存过期时间
                e.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);

                //设置滑动过期时间
                e.SlidingExpiration = TimeSpan.FromSeconds(10);
                return new Person(id, name, new Random().Next(1, 100));
            });
           
            return person;

        }


        /// <summary>
        /// 使用redis做缓存服务器
        /// 1,Install-Package Microsoft.Extensions.Caching.StackExchangeRedis
        /// 2,注册组件
        ///builder.Services.AddStackExchangeRedisCache(e =>
        ///{
        ///     e.Configuration = "localhost";
        ///     e.InstanceName = "webname";
        ///});
        /// </summary>
        [HttpGet("UseRedis")]
        public async Task<Person?> UseRedis([FromServices]IDistributedCache distCache,long id)
        {
            Person? person;
            string personValue = await distCache.GetStringAsync($"Person{id}");

            if (personValue == null)
            {
                var name = RandomChineseName.GenerateName();
                person = new Person(id, name,  Random.Shared.Next(1, 100));
                await distCache.SetStringAsync($"Person{id}", JsonSerializer.Serialize(person));
            }
            else
            {
                person= JsonSerializer.Deserialize<Person?>(personValue);
            }

            return person;
        }
    }

}
