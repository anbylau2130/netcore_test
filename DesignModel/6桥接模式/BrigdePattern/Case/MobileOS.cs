
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrigdePattern.Case{
    /// <summary>
    /// 手机操作系统
    /// </summary>
    public abstract class MobileOS {

        /// <summary>
        /// 手机操作系统
        /// </summary>
        public MobileOS() {
        }

        protected Application ApplicationInstance {
            get; set;
        }

        public abstract void Run();

        /// <summary>
        /// @param application
        /// </summary>
        public void SetApplication(Application application) {
           this.ApplicationInstance = application;
        }

    }
}