EFCore中使用MediatR

1.NuGet安装包 Install-Package MediatR

2.创建接口
public interface IDomainEvents
{
    IEnumerable<INotification> GetDomainEvents();
    void AddDomainEvent(INotification notification);

    void ClearDomainEvents();
}

3.创建抽象实体父类

public abstract class BaseEntity:IDomainEvents
{
    private IList<INotification> events=new List<INotification>();

    public IEnumerable<INotification> GetDomainEvents()
    {
        return events;
    }

    public void AddDomainEvent(INotification notification)
    {
        events.Add(notification);
    }

    public void ClearDomainEvents()
    {
       events.Clear();
    }
}


4.数据库实体类集成抽象父类

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


5.消息的发布者
public record NewMaterialNotification(string Name) : INotification;


6.消息的处理者
public class NewMaterialHandlers : NotificationHandler<NewMaterialNotification>
{
    protected override void Handle(NewMaterialNotification notification)
    {
        Console.WriteLine(notification.Name);
    }
}

7.再控制器中使用


    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MediatRController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly BaseDbContext dbContext;

        public MediatRController(IMediator mediator, BaseDbContext dbContext)
        {
            this.mediator = mediator;
            this.dbContext= dbContext;
        }

        [NotCheckJwtVersion]
        [HttpPost]
        public int Add(int a,int b)
        {
            this.mediator.Publish(new PostNotification("hello guys"));
            return a+b;
        }

        [NotCheckJwtVersion]
        [HttpPost]
        public async Task CreateMaterial()
        {
            Material mtr = new Material("物料001","kg",18.001);
            dbContext.Add(mtr);
            await dbContext.SaveChangesAsync();
        }
    }


8.Program.cs中进行DI注入
builder.Services.AddScoped<BaseDbContext>();