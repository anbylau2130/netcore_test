using Nacos.V2;

namespace AspNetCoreNacos
{
    public class NacosConfigListener : IListener
    {
        string _nameSpace, _dataId, _group;

        /// <summary>
        /// 配置变化监听
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <param name="dataId"></param>
        /// <param name="group"></param>
        public NacosConfigListener(string nameSpace, string dataId, string group)
        {
            _nameSpace = nameSpace;
            _dataId = dataId;
            _group = group;
        }
        /// <summary>
        /// 接收配置方法
        /// </summary>
        /// <param name="configInfo"></param>
        public void ReceiveConfigInfo(string configInfo)
        {
            Console.WriteLine("recieve:" + configInfo);
            NacosConfigUtil.Set(_nameSpace, _dataId, _group, configInfo);
        }
    }
}
