
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.OldImp
{
    public class Person
    {

        public Person()
        {
        }
        public Person(string name)
        {
            this.Name= name;
        }

        public string Name
        {
            get; set;
        }

        public List<Costume> Costumes
        {
            get; set;
        } = new List<Costume>();


        public void Show()
        {
            Console.WriteLine(this.Name);
            foreach (Costume costume in Costumes)
            {
                costume.Show();
            }
        }

    }
}