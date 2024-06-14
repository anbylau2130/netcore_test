using Nacos.AspNetCore.V2;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//×¢²áNacos
builder.Services.AddNacosAspNet(builder.Configuration,"nacos");
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
