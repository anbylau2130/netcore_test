
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrigdePattern.Case
{
    public class Sharp
    {

        private Color color { get; set; }
        public string Name { get; set; }
        public Sharp() { }
        public Sharp(string name)
        {
            this.Name = name;
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }


        private string GetColor()
        {
            StringBuilder sb1 = new StringBuilder();

            if (color is Green)
            {
                sb1.Append("ÂÌÉ«");
            }
            else
            {
                sb1.Append("ºìÉ«");
            }
            return sb1.ToString();
        }

        public virtual void Draw()
        {
           
            Console.WriteLine(this.GetColor() + this.Name);
        }

    }
}