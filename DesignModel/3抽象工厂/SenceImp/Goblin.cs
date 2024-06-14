
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstactFactory.SenceImp{
    /// <summary>
    /// 哥布林
    /// </summary>
    public class Goblin : Enemy {

        /// <summary>
        /// 哥布林
        /// </summary>
        public Goblin() {
        }

        public override void Run()
        {
            Console.WriteLine("哥布林Runing!");
        }

        public override void Attack()
        {
            Console.WriteLine("哥布林Attacking!");
        }

        public override void Eat()
        {
            Console.WriteLine("哥布林Eating!");
        }
    }
}