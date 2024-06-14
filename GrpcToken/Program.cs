using GrpcToken;
using GrpcToken.Apis;
using GrpcToken.Services;
using Hiuyeung.Common.Extentions.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();
builder.Services.AddJwtService(builder.Configuration);
builder.Services.AddTransient<ITokenService,TokenServiceImpl>();
builder.Services.AddTransient<IUserService, UserServiceImpl>();
builder.Services.AddAuthentication();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseJwtService();
app.MapControllers();
app.MapGrpcService<UserServiceGrpc>();
app.MapGrpcService<TokenServiceGrpc>();

app.Run();
