using Consul;
using Consul.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Hiuyeung.Common.Extentions.Consul;

public static class ConsulServiceExtention
{
    public static IServiceCollection AddConsulService(this IServiceCollection services, IConfiguration configuration,string sectionName= "Consul")
    {


        var consulSection = configuration.GetSection(sectionName);
        services.Configure<ConsulConfig>(consulSection);
        var consulOptions = consulSection.Get<ConsulConfig>();
        if (consulOptions == null)
        {
            throw new Exception();
        }

        services.AddConsul(options =>
        {
            options.Address = new Uri(consulOptions.HostAddress);
        });

        services.AddConsulServiceRegistration(options =>
        {
            options.ID = $"{consulOptions.ServiceAddress}:{consulOptions.Port}";
            options.Name = $"{consulOptions.ServiceName}";
            options.Port = consulOptions.Port;
            options.Address = consulOptions.ServiceAddress;

            //健康检测

            options.Check = new()
            {
                //1.如果服务不可用，多久将其移除
                DeregisterCriticalServiceAfter = TimeSpan.FromMinutes(5),
                //2.健康检测的间隔时间
                Interval = TimeSpan.FromSeconds(10),
                //3.健康检测检测地址
                HTTP = $"http://{options.Address}:{options.Port}{consulOptions.ServiceHealthCheck}",
                //4.超时时间
                Timeout = TimeSpan.FromSeconds(5)
            };
        });

        return services;
    }
}