
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstactFactory.SenceImp{
    /// <summary>
    /// 人类
    /// </summary>
    public class Human : Enemy {

        /// <summary>
        /// 人类
        /// </summary>
        public Human() {
        }

        public override void Run()
        {
            Console.WriteLine("人类Runing");
        }

        public override void Attack()
        {
            Console.WriteLine("人类Attacking");
        }

        public override void Eat()
        {
            Console.WriteLine("人类Eating");
        }
    }
}