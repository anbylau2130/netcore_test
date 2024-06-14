using System.Collections.Concurrent;
using Hiuyeung.Common.Extentions;

namespace AspNetCoreNacos
{
    public static class NacosConfigUtil
    {
        static ConcurrentDictionary<string, IConfigurationRoot> _cache;

        static ConcurrentDictionary<string, ConcurrentDictionary<string, ConcurrentDictionary<string, string>>> _configDic;

        //namaspace用于环境，在运行中一般不变
        static string _nameSpace;

        /// <summary>
        /// Nacos配置工具类
        /// </summary>
        static NacosConfigUtil()
        {
            _configDic = new ConcurrentDictionary<string, ConcurrentDictionary<string, ConcurrentDictionary<string, string>>>();
            _cache = new ConcurrentDictionary<string, IConfigurationRoot>();
        }

        /// <summary>
        /// GetRoot
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        static IConfigurationRoot GetRoot(string content)
        {
            return new ConfigurationBuilder().AddJsonStream(content.ToStream()).Build();
        }


        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <param name="groupName"></param>
        /// <param name="dataId"></param>
        /// <param name="content"></param>
        public static void Set(string nameSpace, string groupName, string dataId, string content)
        {
            _nameSpace = nameSpace;
            if (!_configDic.ContainsKey(nameSpace))
            {
                _configDic[nameSpace] = new ConcurrentDictionary<string, ConcurrentDictionary<string, string>>();
            }
            if (!_configDic[nameSpace].ContainsKey(groupName))
            {
                _configDic[nameSpace][groupName] = new ConcurrentDictionary<string, string>();
            }
            _configDic[nameSpace][groupName][dataId] = content;
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="dataId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string Get(string groupName, string dataId)
        {
            if (!_configDic.ContainsKey(_nameSpace))
            {
                throw new NotImplementedException("当前配置还未初始化");
            }
            if (!_configDic[_nameSpace].ContainsKey(groupName))
            {
                return string.Empty;
            }
            if (!_configDic[_nameSpace][groupName].ContainsKey(dataId))
            {
                return string.Empty;
            }
            return _configDic[_nameSpace][groupName][dataId];
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="dataId"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static string? Get(string groupName, string dataId, string sectionName)
        {
            var content = Get(groupName, dataId);
            if (content.IsNullOrEmpty()) return string.Empty;
            return GetRoot(content)[sectionName];
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="groupName"></param>
        /// <param name="dataId"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static T? Get<T>(string groupName, string dataId, string sectionName)
        {
            var content = Get(groupName, dataId);
            if (content.IsNullOrEmpty()) return default;
            return GetRoot(content).GetSection(sectionName).Get<T>();
        }

        /// <summary>
        /// 读取配置字符串
        /// </summary>
        /// <param name="dataId"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static string Read(string dataId, string sectionName)
        {
            return Get("DEFAULT_GROUP", dataId, sectionName);
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataId"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static T Read<T>(string dataId, string sectionName)
        {
            return Get<T>("DEFAULT_GROUP", dataId, sectionName);
        }
    }
}
