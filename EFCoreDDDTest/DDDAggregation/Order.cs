namespace EFCoreDDDTest.DDDAggregation;

public class Order
{
    public int Id { get; set; }
    public string BillNo { get; set; }
    public List<OrderEntry> OrderEntry { get; set; } = new List<OrderEntry>();
    public double TotalAmount { get; set; }

    public void AddOrderEntry(Material mtr, int qty)
    {
        var  orderEntry = OrderEntry.FirstOrDefault(x => x.Material.Id == mtr.Id && x.Qty == qty);

        if (orderEntry==null)
        {
            this.OrderEntry.Add(new OrderEntry()
            {
                Material = mtr,
                Qty = qty
            });
        }
        else
        {
            orderEntry.Qty+= qty;
        }
    }
}


public class OrderEntry
{
    public int Id { get; set; }
    public Material Material { get; set; }
    public double Qty { get; set; }
}

public class Material
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }
}