using MediatR;

namespace AspNetCoreWebApi.MediatR;

public record NewMaterialNotification(string Name) : INotification;