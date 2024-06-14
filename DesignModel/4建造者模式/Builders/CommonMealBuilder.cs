
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuilderPattern.Model;

namespace BuilderPattern.Builders{
    public class CommonMealBuilder : MealBuilder {

        public CommonMealBuilder() {
        }

        public override void BuildFood()
        {
            Meal.Foods.Add(new Food("����", 1, 5));
            Meal.Foods.Add(new Food("ţ���", 1, 28));
        }

        public override void BuildDrink()
        {
            Meal.Drinks.Add(new Drink("�������", 1, 8));
        }
    }
}