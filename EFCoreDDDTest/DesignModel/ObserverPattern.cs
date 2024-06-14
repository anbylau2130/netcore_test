
namespace EFCoreDDDTest.DesignModel;

public class Car
{
    public string Name{get;set;}

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
    }

}

public enum Color { Red,Green,Yellow}


public class Test()
{
   public void DoTest()
    {
        Light light = new Light();
        Car car = new Car();
        car.Name = "宝马";
        Car car2 = new Car();
        car2.Name = "奔驰";
        while (true)
        {
            light.ChangeColor();
            car.Update(light);
        }

    }
}

public class ObServerPattern
{


}