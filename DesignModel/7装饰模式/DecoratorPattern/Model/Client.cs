
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.Model
{
    public class Client
    {

        public Client()
        {
        }

        /// <summary>
        /// 装饰模式是利用SetComponent来对对象进行封装，这样每个装饰对象的实现就和如何使用这个对象分离开了，
        /// 每个装饰对象只关心自己的功能，不需要关心如何被添加到对象链中
        /// 输出：
        /// 具体对象操作
        /// 具体装饰对象A的操作
        /// 具体装饰对象B的操作
        /// </summary>
        public void Test()
        {
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA a = new ConcreteDecoratorA();
            ConcreteDecoratorB b = new ConcreteDecoratorB();
            a.SetComponent(c);
            b.SetComponent(a);
            b.Operation();

        }

    }
}