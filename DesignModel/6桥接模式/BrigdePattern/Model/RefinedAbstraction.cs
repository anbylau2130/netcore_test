
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrigdePattern.Model
{
    public class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(Implementor implementor) : 
            base(implementor)
        {

        }

        public override void Operation()
        {
            implementor.Operation();
        }

    }
}