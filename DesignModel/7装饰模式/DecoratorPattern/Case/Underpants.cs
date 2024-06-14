
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.Case{
    /// <summary>
    /// 裤衩
    /// </summary>
    public class Underpants : Costume {

        /// <summary>
        /// 裤衩
        /// </summary>
        public Underpants() {
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("裤衩");
        }
    }
}