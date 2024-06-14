
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstactFactory.SenceImp;

namespace AbstactFactory.Factory{
    public abstract class SenceFacotry {

        public SenceFacotry() {
        }

        /// <summary>
        /// @return
        /// </summary>
        public abstract Enemy CreateEnemy();

        /// <summary>
        /// @return
        /// </summary>
        public abstract Background CreateBackground();

    }
}