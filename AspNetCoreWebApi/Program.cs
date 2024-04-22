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
//2.ʹ������ע��
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
//ע���쳣����Filter
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
//���÷������˻��� ������MapControllers֮ǰ��UseCors֮��
//�������ͷ�к���Cache-Control=no-cache�����Է������˻���
//��Ӧ״̬Ϊ200��Get��Head���ܱ�����POST�����ǲ��ܱ�����ģ�����ͷ�в��ܺ���Authorization��Set-Cookie�ȡ�
app.UseResponseCaching();
 
app.MapControllers();


app.Run();


