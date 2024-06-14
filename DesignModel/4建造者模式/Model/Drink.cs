
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderPattern.Model{
    public record Drink {

        public Drink(string Name,int Qty,double Price) {
            this.Name = Name;   
            this.Qty = Qty;
            this.Price = Price;
        }

        public string Name;

        public int Qty;

        public double Price;

    }
}