
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.Case{
    /// <summary>
    /// T恤
    /// </summary>
    public class TShirt : Costume {

        /// <summary>
        /// T恤
        /// </summary>
        public TShirt() {
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("T恤");
        }
    }
}