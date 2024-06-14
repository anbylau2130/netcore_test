using MediatR;

namespace AspNetCoreWebApi.MediatR;

public class NewMaterialHandlers : NotificationHandler<NewMaterialNotification>
{
    protected override void Handle(NewMaterialNotification notification)
    {
        Console.WriteLine(notification.Name);
    }
}