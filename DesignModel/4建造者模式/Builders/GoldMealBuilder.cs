
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
            Meal.Foods.Add(new Food("����",1,5));
            Meal.Foods.Add(new Food("��Ƥը����", 1, 18));
            Meal.Foods.Add(new Food("ţ���", 1, 28));
            Meal.Foods.Add(new Food("��ˮ����", 1, 88));

        }

        public override void BuildDrink()
        {
            Meal.Drinks.Add(new Drink("���¿���", 1, 8));
            Meal.Drinks.Add(new Drink("��������",1,12));
        }
    }
}