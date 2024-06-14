namespace AspNetCoreWebApi.MediatR;

/// <summary>
/// 物料信息
/// </summary>
public class Material: BaseEntity
{
    public long Id { get; init; }

    public string Name { get; init; }

    public string Unit { get; private set; }

    public double Price { get; private set ; }

    private Material()
    {

    }

    public Material( string name, string unit, double price)
    {
        Name = name;
        Unit = unit;
        Price = price;
        //注册事件
        AddDomainEvent(new NewMaterialNotification(name));
    }   
    /// <summary>
    /// 修改物料价格
    /// </summary>
    /// <param name="price"></param>
    public void ChangePrice(double price)
    {
        this.Price = price;
        
    }
    /// <summary>
    /// 修改物料单位
    /// </summary>
    /// <param name="unit"></param>
    public void ChangeUnit(string unit)
    {
        this.Unit = unit;
    }

}