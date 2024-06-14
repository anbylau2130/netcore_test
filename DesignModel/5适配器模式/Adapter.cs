
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern{
    /// <summary>
    /// 适配器：将源接口改造成目标接口
    /// </summary>
    public class Adapter : Target {

        private Adaptee Adaptee = new Adaptee();
        /// <summary>
        /// 适配器：将源接口改造成目标接口
        /// </summary>
        public Adapter() {
        }


        public override void Request()
        {
            Adaptee.SpecialRequest();
        }
    }
}