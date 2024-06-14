
using Com.Ctrip.Framework.Apollo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.ConfigureAppConfiguration((context, build) =>
{
    build.AddApollo(context.Configuration.GetSection("apollo"))
    .AddNamespace("appsettings", Com.Ctrip.Framework.Apollo.Enums.ConfigFileFormat.Json)
    .AddDefault();
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
