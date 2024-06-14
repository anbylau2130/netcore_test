
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod{
    public abstract class LogFactory {

        public LogFactory() {
        }

        /// <summary>
        /// @param  
        /// @return
        /// </summary>
        public abstract Log CreateLog();

    }
}