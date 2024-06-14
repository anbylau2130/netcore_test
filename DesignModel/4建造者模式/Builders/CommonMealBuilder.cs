
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
            Meal.Foods.Add(new Food("ÊíÌõ", 1, 5));
            Meal.Foods.Add(new Food("Å£ëîºº±¤", 1, 28));
        }

        public override void BuildDrink()
        {
            Meal.Drinks.Add(new Drink("±ùÕò¿ÉÀÖ", 1, 8));
        }
    }
}