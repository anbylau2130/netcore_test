namespace DesignModel.观察者模式.V3;


/// <summary>
/// 消息发布者
/// </summary>
public abstract class Subject
{
    public List<Observer> Observers { get; set; } = new List<Observer>();

    /// <summary>
    /// 将观察者加入到列表中
    /// </summary>
    /// <param name="observer"></param>
    public void AddObserver(Observer observer)
    {
        this.Observers.Add(observer);
    }

    /// <summary>
    /// 发布消息
    /// </summary>
    public void Publish()
    {
        foreach (var observer in Observers)
        {
            observer.Update(this);

        }
    }
}
/// <summary>
/// 状态观察者
/// </summary>
public abstract class Observer
{
    public abstract void Update(Subject subject);
}

public enum Color { Red, Green, Yellow }

public class Car : Observer
{
    public string Name { get; set; }

    public string Status { get; set; }

    public Car(string name)
    {
        this.Name = name;
    }

    public override void Update(Subject subject)
    {
        var light = subject as Light;
        switch (light.Color)
        {
            case Color.Red:
                Status = "Stop";
                break;
            case Color.Green:
                Status = "Run";
                break;
        }
        Console.WriteLine($"{light.Color.ToString()}-{this.Name}:{this.Status}");
    }
}

public class Light : Subject
{
    public Color Color { get; set; }

    public void ChangeColor()
    {
        switch (Color)
        {
            case Color.Red:
                Color = Color.Green;
                break;
            case Color.Green:
                Color = Color.Red;
                break;
            default:
                Color = Color.Red;
                break;
        }
        this.Publish();
        Thread.Sleep(2000);
    }

}








public class Test()
{
    public void DoTest()
    {
        Light light = new Light();
        light.AddObserver(new Car("BMW"));
        light.AddObserver(new Car("Mercedes-Benz"));
        light.AddObserver(new Car("Peugeot"));
        light.AddObserver(new Car("Volkswagen"));
        light.AddObserver(new Car("Volvo"));
        light.AddObserver(new Car("Ford"));
        light.AddObserver(new Car("Honda"));
        light.AddObserver(new Car("Toyota"));


        while (true)
        {
            light.ChangeColor();
        }

    }
}
