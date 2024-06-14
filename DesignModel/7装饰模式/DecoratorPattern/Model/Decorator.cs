
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.Model{
    public abstract class Decorator : Component {

        public Decorator() {
        }

        private Component component;

        public void SetComponent(Component component)
        {
            this.component=component;
        }

        public override void Operation()
        {
            if (this.component != null)
            {
                this.component.Operation();
            }
        }

    }
}