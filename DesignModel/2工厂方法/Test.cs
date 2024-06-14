
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryMethod.Factory;

namespace FactoryMethod
{
    public class Test
    {


        public void test()
        {
            string factoryClass = "FactoryMethod.Factory";
            var factory =(LogFactory) Activator.CreateInstance(Type.GetType(factoryClass));

            if (factory != null)
            {
                var log=factory.CreateLog();
                log.WriteLog("日志", "info");
            }

            // LogFactory databaseLogFactory = new DataBaseFactory();
            // var databaseLog = databaseLogFactory.CreateLog();
            // databaseLog.WriteLog("数据库日志", "info");
            //
            // LogFactory fileLogFactory = new FileLogFactory();
            // var fileLog = fileLogFactory.CreateLog();
            // fileLog.WriteLog("文件日志", "info");
        }

    }
}