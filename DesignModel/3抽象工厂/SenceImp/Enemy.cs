
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstactFactory.SenceImp{
    public abstract class Enemy {

        public Enemy() {
        }

        public abstract void Run();

        public abstract void Attack();

        public abstract void Eat();

    }
}