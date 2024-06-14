
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstactFactory.SenceImp
{
    /// <summary>
    /// 森林
    /// </summary>
    public class Forest : Background
    {

        /// <summary>
        /// 森林
        /// </summary>
        public Forest()
        {
        }

        public override void Night()
        {
            Console.WriteLine("森林进入夜晚!");
        }

        public override void Afternoon()
        {
            Console.WriteLine("森林进入下午!");
        }

        public override void Morning()
        {
            Console.WriteLine("森林进入上午!");
        }
    }
}