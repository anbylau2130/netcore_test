namespace AspNetCoreNacos
{
    public class NacosConfig
    {
        public NacosConfig() { }

        public bool ConfigUseRpc { get; set; }
        public bool NamingUseRpc { get; set; }
        
        public List<string> ServerAddresses { get; set; }

        public string Namespace { get; set; }


        public List<Listener> Listeners { get; set; }

        public class Listener
        {
            public string DataId { get; set; }
            public string Group { get; set; }
        }
    }
}
