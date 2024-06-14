
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderPattern.Model{
    public class Meal {

        public Meal() {
        }

        public List<Food> Foods { get; set; }=new List<Food>();

        public List<Drink> Drinks=new List<Drink>();

        /// <summary>
        /// @param food
        /// </summary>
        public void AddFood(Food food) {
           this.Foods.Add(food);
        }
        /// <summary>
        /// @param drink
        /// </summary>
        public void AddDrink(Drink drink)
        {
            this.Drinks.Add(drink);
        }


        public void ShowFoodList() {
            foreach (var food in this.Foods)
            {
                Console.WriteLine(food.ToString());
            }

            foreach (var drink in Drinks)
            {
                Console.WriteLine(drink.ToString());
            }
        }

       

    }
}