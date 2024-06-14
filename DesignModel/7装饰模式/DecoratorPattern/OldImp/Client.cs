
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.OldImp{
    public class Client {

        public Client() {
        }

        public void Test() {
           Person person=new Person("Jessica");
            person.Costumes.Add(new TShirt());
            person.Costumes.Add(new BusinessSuit());
            person.Costumes.Add(new Underpants());
            person.Show();
        }

    }
}