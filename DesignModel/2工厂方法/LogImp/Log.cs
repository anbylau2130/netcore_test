
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod{
    public abstract class Log {

        public Log() {
        }

        /// <summary>
        /// @param content 
        /// @param level 
        /// @return
        /// </summary>
        public abstract void WriteLog(string content, string level);
            

    }
}