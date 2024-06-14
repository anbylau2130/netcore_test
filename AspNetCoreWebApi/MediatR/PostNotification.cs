using MediatR;

namespace AspNetCoreWebApi.MediatR;

public record PostNotification(string Body) : INotification;