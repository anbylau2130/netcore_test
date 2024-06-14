
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BrigdePattern.Model
{
    public class Client
    {

        public Client()
        {
        }

        /// <summary>
        /// 桥接模式(Bridge Pattern)：将抽象部分与它的实现部分分离，使它们都可以独立地变化。它是一种对象结构型模式，
        /// 又称为柄体(Handle and Body)模式或接口(Interface)模式。
        /// 
        /// 桥接模式将继承关系转换为关联关系，从而降低了类与类之间的耦合，减少了代码编写量。
        /// 
        /// Abstraction：抽象类
        /// RefinedAbstraction：扩充抽象类
        /// Implementor：实现类接口
        /// ConcreteImplementor：具体实现类
        /// </summary>
        public void Test()
        {
            Abstraction a = new RefinedAbstraction(new ConcreteImplementorA());
            a.Operation();
            Abstraction b = new RefinedAbstraction(new ConcreteImplementorB());
            b.Operation();
        }

    }
}