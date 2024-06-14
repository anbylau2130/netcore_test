
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.Case{
    /// <summary>
    /// 人
    /// </summary>
    public class Person {

        /// <summary>
        /// 人
        /// </summary>
        public Person() {
        }
        public Person(string name)
        {
            this.Name= name;
        }

        public string Name {
            get; set;
        }

        public virtual void Show() {
            Console.WriteLine(this.Name);
        }

    }
}