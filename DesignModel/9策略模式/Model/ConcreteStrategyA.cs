
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern.Model{
    public class ConcreteStrategyA : Strategy {

        public ConcreteStrategyA() {
        }

        public override void AlgorithmInterface()
        {
            Console.WriteLine("À„∑®A");
        }
    }
}