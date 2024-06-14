
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.Model{
    public class ConcreteComponent : Component {

        public ConcreteComponent() {
        }

        public override void Operation()
        {
            Console.WriteLine("具体对象操作");
        }
    }
}