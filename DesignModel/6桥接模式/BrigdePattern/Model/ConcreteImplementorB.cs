
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrigdePattern.Model
{
    /// <summary>
    /// 具体实现B
    /// </summary>
    public class ConcreteImplementorB : Implementor {

        /// <summary>
        /// 具体实现B
        /// </summary>
        public ConcreteImplementorB() {

        }

        public override void Operation()
        {
            Console.WriteLine("具体实现B的方法执行");
        }

    }
}