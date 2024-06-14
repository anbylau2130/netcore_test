
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstactFactory.SenceImp{
    public abstract class Background {

        public Background() {
        }

        public abstract void Night();

        public abstract void Afternoon();

        public abstract void Morning();

    }
}