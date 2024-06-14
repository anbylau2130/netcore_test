
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstactFactory.SenceImp;

namespace AbstactFactory.Factory{
    /// <summary>
    /// 人类工厂
    /// </summary>
    public class HumanFactory : SenceFacotry {

        /// <summary>
        /// 人类工厂
        /// </summary>
        public HumanFactory() {

            Console.WriteLine("人类工厂:人类生活在城市！");
        }

        public override Enemy CreateEnemy()
        {
            Console.WriteLine("CreateEnemy:正在生成人类模型！");
            return new Human();
        }

        public override Background CreateBackground()
        {
            Console.WriteLine("CreateBackground:正在生成城市图像！");
            return new City();
        }
    }
}