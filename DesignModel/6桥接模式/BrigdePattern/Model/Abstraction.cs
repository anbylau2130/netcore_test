
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrigdePattern.Model
{
    public abstract class Abstraction
    {
        protected Implementor implementor;

        public Abstraction(Implementor implementor)
        {
            this.implementor = implementor;

        }

        public virtual void Operation()
        {
            this.implementor.Operation();
        }

    }
}