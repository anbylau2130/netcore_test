
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuilderPattern.Model;

namespace BuilderPattern.Builders{
    public class GoldMealBuilder : MealBuilder {


        public GoldMealBuilder() 
        {
        }
        

        public override void BuildFood()
        {
            Meal.Foods.Add(new Food("ÊíÌõ",1,5));
            Meal.Foods.Add(new Food("´àÆ¤Õ¨¼¦Áø", 1, 18));
            Meal.Foods.Add(new Food("Å£ëîºº±¤", 1, 28));
            Meal.Foods.Add(new Food("¿ÚË®´ó¼¦ÍÈ", 1, 88));

        }

        public override void BuildDrink()
        {
            Meal.Drinks.Add(new Drink("³£ÎÂ¿ÉÀÖ", 1, 8));
            Meal.Drinks.Add(new Drink("±ùÕòÄÃÌú",1,12));
        }
    }
}