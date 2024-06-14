
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.OldImp{
    public class BusinessSuit : Costume {

        public BusinessSuit() {
        }

        public override void Show()
        {
            Console.WriteLine("Î÷×°");
        }
    }
}