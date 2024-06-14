
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstactFactory.Factory;
using AbstactFactory.SenceImp;
using FactoryMethod;
namespace AbstactFactory
{
    public class Test
    {

        public Test()
        {
        }

        public void test()
        {
            //Type senceType=typeof(HumanFactory);

            Type senceType = typeof(GoblinFactory);
            SenceFacotry humanFactory = (SenceFacotry)Activator.CreateInstance(senceType);
            Enemy human = humanFactory.CreateEnemy();
            Background city = humanFactory.CreateBackground();

            human.Eat();
            human.Run();
            human.Attack();

            city.Morning();
            city.Afternoon();
            city.Night();

        }

    }
}