using MediatR;

namespace AspNetCoreWebApi.MediatR;

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