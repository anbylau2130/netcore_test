
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrigdePattern.Model
{
    /// <summary>
    /// 具体实现A
    /// </summary>
    public class ConcreteImplementorA : Implementor {

        /// <summary>
        /// 具体实现A
        /// </summary>
        public ConcreteImplementorA() {
        }

        public override void Operation()
        {
            Console.WriteLine("具体实现A的方法执行");
        }
    }
}