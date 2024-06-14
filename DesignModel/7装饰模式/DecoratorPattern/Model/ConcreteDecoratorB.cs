
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.Model{
    public class ConcreteDecoratorB : Decorator {

        public ConcreteDecoratorB() {
        }

        private void AddedBehavior() {
           
        }

        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("����װ�ζ���B�Ĳ���");
        }

    }
}