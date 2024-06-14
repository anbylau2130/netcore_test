
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrigdePattern.Case{
    public class Android : MobileOS {

        public Android() {
            Console.WriteLine("android系统");
        }

        public override void Run()
        {
            this.ApplicationInstance.Run();
        }
    }
}