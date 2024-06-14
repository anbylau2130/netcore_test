
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
                log.WriteLog("��־", "info");
            }

            // LogFactory databaseLogFactory = new DataBaseFactory();
            // var databaseLog = databaseLogFactory.CreateLog();
            // databaseLog.WriteLog("���ݿ���־", "info");
            //
            // LogFactory fileLogFactory = new FileLogFactory();
            // var fileLog = fileLogFactory.CreateLog();
            // fileLog.WriteLog("�ļ���־", "info");
        }

    }
}