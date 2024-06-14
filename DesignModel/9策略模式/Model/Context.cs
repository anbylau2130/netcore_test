
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern.Model{
    public class Context {

        public Context(Strategy strategy) {
            this.Strategy = strategy;
        }

        protected Strategy Strategy {
            get; set;
        }

        public void ContextInterface() {
            Strategy.AlgorithmInterface();
        }


    }
}