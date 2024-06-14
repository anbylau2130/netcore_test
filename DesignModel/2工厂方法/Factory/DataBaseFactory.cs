
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryMethod.LogImp;

namespace FactoryMethod.Factory{
    public class DataBaseFactory : LogFactory {

        public DataBaseFactory() {
        }

        public override Log CreateLog()
        {
            return new DataBaseLog();
        }
    }
}