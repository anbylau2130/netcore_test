
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrigdePattern.Case{
    public class HongMeng : MobileOS {

        public HongMeng() {
            Console.WriteLine("����ϵͳ");
        }

        public override void Run()
        {
            this.ApplicationInstance.Run();
        }
    }
}