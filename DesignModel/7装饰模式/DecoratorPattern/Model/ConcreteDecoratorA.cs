
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.Model{
    public class ConcreteDecoratorA : Decorator {

        public ConcreteDecoratorA() {
        }

        private  string AddedState {
            get; set;
        }


        public override void Operation()
        {
            base.Operation();
            this.AddedState = "New State";

            Console.WriteLine("具体装饰对象A的操作");
        }



    }
}