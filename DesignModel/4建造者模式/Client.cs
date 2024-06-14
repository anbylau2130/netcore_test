using BuilderPattern.Builders;

namespace BuilderPattern;

public class Client
{
    public void Test()
    {
        KFCWaiter waiter = new KFCWaiter(new GoldMealBuilder());
        var meal=waiter.BuildMeal();
        meal.ShowFoodList();
    }
}