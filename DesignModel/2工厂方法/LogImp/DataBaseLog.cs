
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
            string result = $"数据库日志：内容{content};日志级别{level}";
            Console.WriteLine(result);
        }
    }
}