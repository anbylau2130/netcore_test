
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern{
    /// <summary>
    /// 需要适配的类
    /// </summary>
    public class Adaptee {

        /// <summary>
        /// 需要适配的类
        /// </summary>
        public Adaptee() {
        }

        public void SpecialRequest() {
            Console.WriteLine("特殊请求!");
        }


    }
}