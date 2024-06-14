
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.OldImp{
    public class Underpants : Costume {

        public Underpants() {
        }

        public override void Show()
        {
            Console.WriteLine("´ó¿ãñÃ");
        }
    }
}