using System.Collections;
using MediatR;

namespace AspNetCoreWebApi.MediatR;

public interface IDomainEvents
{
    IEnumerable<INotification> GetDomainEvents();
    void AddDomainEvent(INotification notification);

    void ClearDomainEvents();
}