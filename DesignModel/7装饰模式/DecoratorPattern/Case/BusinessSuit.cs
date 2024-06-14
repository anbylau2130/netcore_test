
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.Case{
    /// <summary>
    /// 西装
    /// </summary>
    public class BusinessSuit : Costume {

        /// <summary>
        /// 西装
        /// </summary>
        public BusinessSuit() {
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("西装");
        }
    }
}