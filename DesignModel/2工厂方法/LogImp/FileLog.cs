
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.LogImp{
    public class FileLog : Log {

        public FileLog() {
        }

        public override void WriteLog(string content, string level)
        {
            string result = $"文件日志：内容{content};日志级别{level}";
            Console.WriteLine(result);
        }
    }
}