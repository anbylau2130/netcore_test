
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.Case
{
    /// <summary>
    /// 服饰
    /// </summary>
    public class Costume : Person
    {

        /// <summary>
        /// 服饰
        /// </summary>
        public Costume()
        {
        }

        protected Person Person = new Person();

        public void Decorate(Person person)
        {
            this.Person = person;
        }
        public override void Show()
        {
            if (Person != null)
            {
                Person.Show();
            }
        }
    }
}