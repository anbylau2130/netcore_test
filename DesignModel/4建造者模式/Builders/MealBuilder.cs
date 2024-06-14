
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuilderPattern.Model;

namespace BuilderPattern.Builders
{
    public abstract class MealBuilder
    {

        public Meal Meal { get; set; } = new Meal();
        public MealBuilder()
        {
        }

        /// <summary>
        /// @return
        /// </summary>
        public Meal GetMeal()
        {
            this.BuildFood();
            this.BuildDrink();
            return this.Meal;
        }


        public abstract void BuildFood();
        public abstract void BuildDrink();

    }
}