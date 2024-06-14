namespace DesignModel.观察者模式.V1;

public class Car
{
    public string Name { get; set; }

    public string Status { get; set; }

    public void Update(Light light)
    {
        switch (light.Color)
        {
            case Color.Red:
                Status = "Stop";
                break;
            case Color.Green:
                Status = "Run";
                break;
        }
    }
}

public class Light
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
        Thread.Sleep(2000);
    }

}

public enum Color { Red, Green, Yellow }


public class Test()
{
    public void DoTest()
    {
        Light light = new Light();
        Car car1 = new Car();
        car1.Name = "宝马";
        Car car2 = new Car();
        car2.Name = "奔驰";
        while (true)
        {
            light.ChangeColor();
            car1.Update(light);
            car2.Update(light);
            Console.WriteLine($"{light.Color.ToString()}-{car1.Name}{car1.Status}");
            Console.WriteLine($"{light.Color.ToString()}-{car2.Name}{car2.Status}");
        }

    }
}
