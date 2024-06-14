namespace StrategyPattern.Model;

public class Client
{
    public void Test()
    {
        Context context;
        context=new Context(new ConcreteStrategyA());
        context.ContextInterface();
        context = new Context(new ConcreteStrategyB());
        context.ContextInterface();
    }
}