using GrpcJsonConvert.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddSwaggerGen().AddGrpcSwagger();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.MapGrpcService<GreeterService>();
app.Run();
