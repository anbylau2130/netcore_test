using EmptygRpcServer.Apis;
using EmptygRpcServer.Services;

var builder = WebApplication.CreateBuilder(args);


//����Grpc����
builder.Services.AddGrpc();
builder.Services.AddTransient<IUserService,UserServiceImpl>();


var app = builder.Build();

app.MapGrpcService<UserServiceGrpc>();
app.Run();
