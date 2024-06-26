
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuilderPattern.Builders;
using BuilderPattern.Model;

namespace BuilderPattern
{
    public class KFCWaiter
    {

        private MealBuilder mealBuilder;

        public  KFCWaiter(MealBuilder mealBuilder)
        {
            this.mealBuilder = mealBuilder;
        }


        /// <summary>
        /// 造者模式(Builder Pattern)：将一个复杂对象的构建与它的表示分离，
        /// 使得同样的构建过程可以创建不同的表示。
        /// 建造者模式是一步一步创建一个复杂的对象，
        /// 它允许用户只通过指定复杂对象的类型和内容就可以构建它们，
        /// 用户不需要知道内部的具体构建细节。建造者模式属于对象创建型模式。
        /// 根据中文翻译的不同，建造者模式又可以称为生成器模式。
        /// </summary>
        public Meal BuildMeal()
        {
            var meal = this.mealBuilder.GetMeal();
            return meal;
        }

    }
}