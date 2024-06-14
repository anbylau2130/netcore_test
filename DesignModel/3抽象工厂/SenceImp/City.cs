
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstactFactory.SenceImp{
    /// <summary>
    /// 城市
    /// </summary>
    public class City : Background {

        /// <summary>
        /// 城市
        /// </summary>
        public City() {
        }

        public override void Night()
        {
            Console.WriteLine("城市进入夜晚!");
        }

        public override void Afternoon()
        {
            Console.WriteLine("城市进入下午！");
        }

        public override void Morning()
        {
            Console.WriteLine("城市进入上午!");
        }
    }
}