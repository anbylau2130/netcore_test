
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.LogImp{
    public class DataBaseLog : Log {

        public DataBaseLog() {
        }

        public override void WriteLog(string content, string level)
        {
            string result = $"���ݿ���־������{content};��־����{level}";
            Console.WriteLine(result);
        }
    }
}