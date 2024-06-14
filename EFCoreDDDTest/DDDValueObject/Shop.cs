namespace EFCoreDDDTest.DDDValueObject;

public class Shop
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Geo Location { get; set; }
}

public record Geo
{
    public double Latitude { get; init; }
    public double Longitude { get; init; }
    private Geo() { }
    public Geo(double latitude, double longitude)
    {
        if(latitude < 0.0) latitude = 0.0;
        if(longitude < 0.0) longitude = 0.0;
        this.Latitude = latitude;
        this.Longitude = longitude;
    }
}