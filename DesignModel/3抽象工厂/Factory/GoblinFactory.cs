
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstactFactory.SenceImp;

namespace AbstactFactory.Factory{
    /// <summary>
    /// 哥布林工厂
    /// </summary>
    public class GoblinFactory : SenceFacotry {

        /// <summary>
        /// 哥布林工厂
        /// </summary>
        public GoblinFactory() {
            Console.WriteLine("哥布林工厂:哥布林住在森林里！");
        }

        public override Enemy CreateEnemy()
        {
            Console.WriteLine("正在生成哥布林模型！");
            return new Goblin();
        }

        public override Background CreateBackground()
        {
            Console.WriteLine("正在生成森林图像!");
            return new Forest();
        }
    }
}