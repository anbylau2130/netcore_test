using EFCoreDDDTest.DDDAggregation;
using EFCoreDDDTest.DDDEnum;
using EFCoreDDDTest.DDDValueObject;

namespace EFCoreDDDTest;

public class Test
{
    /// <summary>
    /// 通过枚举进行复杂类型的定义，再通过FluentApi进行配置数据库中保存枚举值还是字符串
    /// </summary>
    public void Enum2StringTest()
    {
        using (AppDbContext ctx = new AppDbContext())
        {
            var product1 = new Product();
            product1.Name = "AAA";
            product1.Currency = Currency.CNY;
            var product2 = new Product();
            product2.Name = "BBB";
            product2.Currency = Currency.USD;

            ctx.Add(product1);
            ctx.Add(product2);

            ctx.SaveChanges();
        }
    }


    public void ValueObjectTest()
    {

        using (AppDbContext ctx = new AppDbContext())
        {
            var shop = new Shop();
            shop.Name = "商店1";
            shop.Location = new Geo(18, 9);
            ctx.Shops.Add(shop);
            ctx.SaveChanges();
        }
    }

   /// <summary>
   /// 给不同的属性设置不同的数据类型或长度
   /// </summary>
    public void ValueObjectTest1()
    {
        using (AppDbContext ctx = new AppDbContext())
        {
            var blog = new Blog();
            blog.Title = new MultiLangString("中文标题", "english title");
            blog.Body = new MultiLangString("中文内容", "english body");
            ctx.Blogs.Add(blog);
            ctx.SaveChanges();
        }

    }


    /// <summary>
    /// 聚合在访问的时候通过聚合根，Order就是聚合根，OrderEntry相当于要通过Order进行操作
    /// </summary>
    public void Aggregation()
    {
        using (AppDbContext ctx = new AppDbContext())
        {
            Order order = new Order();
            order.AddOrderEntry(new Material { Name = "物料001", Unit = "KG" }, 100);
            ctx.Orders.Add(order);
            ctx.SaveChanges();
        }


    }


}