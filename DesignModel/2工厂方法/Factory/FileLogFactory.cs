
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryMethod.LogImp;

namespace FactoryMethod.Factory{
    public class FileLogFactory : LogFactory {

        public FileLogFactory() {

        }

        public override Log CreateLog()
        {
            return new FileLog();
        }
    }
}