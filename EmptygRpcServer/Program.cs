using EmptygRpcServer.Apis;
using EmptygRpcServer.Services;

var builder = WebApplication.CreateBuilder(args);


//增加Grpc服务
builder.Services.AddGrpc();
builder.Services.AddTransient<IUserService,UserServiceImpl>();


var app = builder.Build();

app.MapGrpcService<UserServiceGrpc>();
app.Run();
