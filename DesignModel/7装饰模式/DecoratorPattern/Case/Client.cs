
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.Case{
    public class Client {

        public Client() {
        }

        public void Test() {
            Person person=new Person("Jessica");
            var tshirt = new TShirt();
            var businessSuit = new BusinessSuit();
            var underpants = new Underpants();
            tshirt.Decorate(person);
            businessSuit.Decorate(tshirt);
            underpants.Decorate(businessSuit);
            underpants.Show();
        }

    }
}