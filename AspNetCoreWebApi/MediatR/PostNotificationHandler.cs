using MediatR;

namespace AspNetCoreWebApi.MediatR;

public class PostNotificationHandler:NotificationHandler<PostNotification>
{
    protected override void Handle(PostNotification notification)
    {
       Console.WriteLine(notification.Body);
    }
}