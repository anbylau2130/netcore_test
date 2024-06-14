1.安装Consul
install-package Consul.AspNetCore


2.appsettings.json中增加配置项
 "Consul": {
    "HostAddress": "http://127.0.0.1:8500",
    "ServiceAddress": "localhost",
    "Port": 5201,    --launchSettings.json中查看
    "ServerName": "AspNetCoreConsul"
  }

3.Program.cs中进行注册-创建扩展类ConsulServiceExtention
public static class ConsulServiceExtention
{
    public static IServiceCollection AddConsulService(this IServiceCollection services,IConfiguration configuration)
    {

   
        var consulSection = configuration.GetSection("Consul");
        services.Configure<ConsulConfig>(consulSection);
        var consulOptions = consulSection.Get<ConsulConfig>();
        
        services.AddConsul(options =>
        {
            options.Address = new Uri(consulOptions.HostAddress);
        });

        services.AddConsulServiceRegistration(options =>
        {
            options.ID=Guid.NewGuid().ToString();
            options.Name = consulOptions?.ServerName;
            options.Port = consulOptions.Port;
            options.Address = consulOptions.ServerAddress;
            //健康检测

            options.Check = new()
            {
                //1.如果服务不可用，多久将其移除
                DeregisterCriticalServiceAfter = TimeSpan.FromMinutes(5),
                //2.健康检测的间隔时间
                Interval = TimeSpan.FromSeconds(10),
                //3.健康检测检测地址
                HTTP = $"http://{options.Address}:{options.Port}/Health/GetHealthCheck",
                //4.超时时间
                Timeout = TimeSpan.FromMinutes(1)
            };
        });
        return services;
    }

}


4.新建Controller设置心跳节点
namespace AspNetCoreConsul.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHealthCheck()
        {
            return Ok($"当前时间{DateTime.Now}");
        }
    }
}
