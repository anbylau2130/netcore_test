namespace Hiuyeung.Common.Extentions.Consul;

/// <summary>
/// Consul配置节点：
/// 1.开发环境中launchSettings.json中的localhost改成0.0.0.0
/// 2.在appsettings.json配置文件中增加 Consul配置
///  "Consul": {
///      "HostAddress": "http://127.0.0.1:8500",
///      "ServiceAddress": "172.18.112.1",  #本机使用WSL中docker中部署的Consul所以这里使用WSL中的宿主机IP
///      "Port": 5187,
///      "ServiceName": "AspNetCoreConsul.Client",
///      "ServiceHealthCheck": "/Health/Check" 
///   }
///   3.Program.cs中增加
///   builder.Services.AddConsulService(builder.Configuration);  //注册Consul 
/// </summary>
public class ConsulConfig
{


    /// <summary>
    /// Consul主机地址
    /// </summary>
    public string? HostAddress { get; set; }
    /// <summary>
    /// 端口
    /// </summary>
    public int Port { get; set; }
    /// <summary>
    /// 服务地址
    /// </summary>
    public string? ServiceAddress { get; set; }
    /// <summary>
    /// 服务名称
    /// </summary>
    public string? ServiceName { get; set; }

    /// <summary>
    /// 健康检测路径
    /// </summary>
    public string? ServiceHealthCheck { get; set; }
}