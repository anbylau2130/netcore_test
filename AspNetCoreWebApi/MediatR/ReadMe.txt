MediatR的使用：

1.NuGet安装包 Install-Package MediatR

2.Program.cs中调用AddMediatR()

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

3.定义一个在消息的发布者和处理者之间进行数据传递的类，这个类需要实现INotification接口。一般用record类型

public record PostNotification(string Body) : INotification;


4.消息的处理者需要实现NotificationHandler<TNotification>接口，其中的泛型参数TNotification代表此消息处理者要处理的消息类型。

public class PostNotificationHandler:NotificationHandler<PostNotification>
{
    protected override void Handle(PostNotification notification)
    {
       Console.WriteLine(notification.Body);
    }
}

5.在需要发布消息的类中注入IMediator类型的服务，然后调用Publish方法来发布消息.Send()方法是用来发布一对一消息的，而Publish()方法是用来发布一对多消息的。

[Route("api/[controller]/[action]")]
[ApiController]
public class MediatRController : ControllerBase
{
    private readonly IMediator mediator;

    public MediatRController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [NotCheckJwtVersion]
    [HttpPost]
    public int Add(int a,int b)
    {
        this.mediator.Publish(new PostNotification("hello guys"));
        return a+b;
    }
}

