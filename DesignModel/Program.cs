using BuilderPattern;
using BuilderPattern.Builders;

namespace DesignModel;

public class Program
{
    public static void Main()
    {
        //new FactoryMethod.Test().test();
        //new AbstactFactory.Test().test();
        //Console.WriteLine("黄金套餐");
        //new KFCWaiter().BuildMeal(new GoldMealBuilder());
        //Console.WriteLine("普通套餐");
        //new KFCWaiter().BuildMeal(new CommonMealBuilder());
        //new BuilderPattern.Client().Test();
        //new BrigdePattern.Model.Client().Test();
        //new BrigdePattern.Case.Client().Test();
        //new DecoratorPattern.Model.Client().Test();
        //new DecoratorPattern.OldImp.Client().Test();
        //new DecoratorPattern.Case.Client().Test();
        // new BrigdePattern.Case.Client().Test();
        new StrategyPattern.Model.Client().Test();
    }
}