using AspNetCoreWebApi;
using AspNetCoreWebApi.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//2.使用依赖注入
builder.Services.AddScoped<Calculator>();


builder.Services.AddMemoryCache();


builder.Services.AddStackExchangeRedisCache(e =>
{
    e.Configuration = "127.0.0.1";
    e.InstanceName = "webname";
});

string[] urls = ["http://127.0.0.1:3000"];
builder.Services.AddCors(opt=>
        opt.AddDefaultPolicy(
            b=>b.WithOrigins(urls)
            //.AllowAnyOrigin() 
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials())
);
//注册异常处理Filter
builder.Services.Configure<MvcOptions>(options =>
{
    options.Filters.Add<WebExceptionFilter>();
    options.Filters.Add<WebActionFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}


app.UseHttpsRedirection();

app.UseAuthorization();


app.UseCors();
//启用服务器端缓存 必须在MapControllers之前，UseCors之后
//如果请求头中含有Cache-Control=no-cache则会忽略服务器端缓存
//相应状态为200的Get，Head可能被缓存POST请求是不能被缓存的；报文头中不能含有Authorization，Set-Cookie等。
app.UseResponseCaching();
 
app.MapControllers();


app.Run();


