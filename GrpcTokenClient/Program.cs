

using Grpc.Net.ClientFactory;
using GrpcTokenClient;
using Hiuyeung.Common.Extentions.Swagger;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerAuthor();


Action<GrpcClientFactoryOptions> options = (p) =>
{
    p.Address = new Uri("http://localhost:5048");
};

builder.Services.AddGrpcClient<UserService.UserServiceClient>(options)
    .AddCallCredentials(async (conteext, metadata) =>
{
    var serviceProvider = builder.Services.BuildServiceProvider();
    var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
    var token = httpContextAccessor.HttpContext.Request.Headers.Authorization;
    if (!string.IsNullOrWhiteSpace(token))
    {
        metadata.Add("Authorization", $"{token}");
    }
}).ConfigureChannel(p=>p.UnsafeUseInsecureChannelCallCredentials=true); 
builder.Services.AddGrpcClient<TokenService.TokenServiceClient>(options);


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
