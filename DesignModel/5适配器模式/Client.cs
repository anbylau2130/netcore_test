
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern{
    public class Client {

        public Client() {
        }
        /// <summary>
        /// 适配器模式将不能通用的方法改造成目标对象
        /// 适配器模式(Adapter Pattern) ：将一个接口转换成客户希望的另一个接口，
        /// 适配器模式使接口不兼容的那些类可以一起工作，其别名为包装器(Wrapper)。
        /// 适配器模式既可以作为类结构型模式，也可以作为对象结构型模式。
        /// 
        /// 使用一个已经存在的类，但如果它的接口，也就是它的方法和你要求的不相同时，就应该使用适配器模式。
        /// 两个类所做的事情相同或类似，但是具有不同的接口
        /// </summary>
        public void Test() {
            Target target = new Adapter();
            target.Request();
        }

    }
}