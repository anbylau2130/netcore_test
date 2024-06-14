namespace EFCoreDDDTest.DDDEnum;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Currency Currency { get; set; }
}


public enum Currency
{
    CNY,USD,NZD
}