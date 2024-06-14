namespace DesignModel.观察者模式.V2;

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

        List<Car> cars= new List<Car>();
        
        Car car1 = new Car();
        car1.Name = "宝马";
        Car car2 = new Car();
        car2.Name = "奔驰";

        cars.Add(car1);
        cars.Add(car2);
        while (true)
        {
            foreach (var car in cars)
            {
                light.ChangeColor();
                car.Update(light);
                Console.WriteLine($"{light.Color.ToString()}-{car.Name}{car.Status}");
            }
        }

    }
}
