
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.OldImp{
    public class TShirt : Costume {

        public TShirt() {
        }

        public override void Show()
        {
            Console.WriteLine("TÐô");
        }
    }
}