using Nacos.V2.DependencyInjection;
using Nacos.V2;
using Hiuyeung.Common.Extentions;

namespace AspNetCoreNacos
{
    public static class NacosUtil
    {
        public static void GetNacosConfigs(this IServiceCollection services, IConfiguration configuration)
        {
            var nacosConfig = configuration.GetSection("NacosConfig").Get<NacosConfig>();
            services.AddNacosV2Config((n) =>
            {
                n.ConfigUseRpc = nacosConfig.ConfigUseRpc;
                n.NamingUseRpc = nacosConfig.NamingUseRpc;
                n.ServerAddresses = nacosConfig.ServerAddresses;
                n.ListenInterval = 3000;
                n.Namespace = nacosConfig.Namespace;
            });
            var serviceProvider = services.BuildServiceProvider();
            var configSvc = serviceProvider.GetService<INacosConfigService>();
            if (configSvc == null) throw new NotImplementedException("nacos初始化失败");

            if (nacosConfig != null && nacosConfig.Listeners != null && nacosConfig.Listeners.Count > 0)
            {
                foreach (var item in nacosConfig.Listeners)
                {
                    //初始化配置变化监听
                    configSvc.AddListener(item.DataId, item.Group, new NacosConfigListener(nacosConfig.Namespace, item.DataId, item.Group));
                    //初始化数据
                    var content = configSvc.GetConfig(item.DataId, item.Group, 3000).Result;
                    if (content.IsNotNullOrEmpty())
                        NacosConfigUtil.Set(nacosConfig.Namespace, item.Group, item.DataId, content);
                }
            }
        }
    }
}
