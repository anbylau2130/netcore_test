
using AspNetCoreConsul;
using Consul;
using Consul.AspNetCore;
using Hiuyeung.Common.Extentions.Consul;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//×¢²áConsul
builder.Services.AddConsulService(builder.Configuration);

//
// #region ¿çÓò·ÃÎÊ¿ØÖÆ
// string[] urls = ["http://172.18.112.1:5201", "http://172.18.113.91/5201","http://localhost:"];
// builder.Services.AddCors(opt =>
//     opt.AddDefaultPolicy(
//         b => b.WithOrigins(urls)
//             .AllowAnyOrigin() 
//             .AllowAnyMethod()
//             .AllowAnyHeader()
//             .AllowCredentials())
// );
// #endregion




var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
// app.UseHttpsRedirection();
//
// app.UseAuthorization();

app.MapControllers();


app.Run();
