using EmptygRpcClient;
using EmptygRpcServer;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddGrpc();

builder.Services.AddSwaggerGen();



builder.Services.AddGrpcClient<UserService.UserServiceClient>(p =>
{
    p.Address = new Uri("http://localhost:5142");
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseRouting();
app.MapControllers();

app.Run();
