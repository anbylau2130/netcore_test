using Winton.Extensions.Configuration.Consul;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.ConfigureAppConfiguration((context, config) =>
{
    var env = context.HostingEnvironment;
    context.Configuration=config.Build();
    string consul_url = context.Configuration["ConsulUrl"];
    //单文件
    string consulFileName = $"appsettings.{env.EnvironmentName}.json";
    //多服务
    //string consulFileName = $"{env.ApplicationName}/appsettings.{env.EnvironmentName}.json";

    config.AddConsul(consulFileName, options =>
    {
        options.Optional = true;
        options.ReloadOnChange = true;
        options.OnLoadException = exceptionException =>
        {
            exceptionException.Ignore = true;
        };
        options.ConsulConfigurationOptions = cco =>
        {
            cco.Address = new Uri(consul_url);
        };
    });
    context.Configuration = config.Build();
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();
