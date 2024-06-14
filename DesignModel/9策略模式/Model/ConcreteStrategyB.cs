
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern.Model{
    public class ConcreteStrategyB : Strategy {

        public ConcreteStrategyB() {
        }

        public override void AlgorithmInterface()
        {
            Console.WriteLine("À„∑®B");
        }
    }
}