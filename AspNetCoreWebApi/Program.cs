using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using AspNetCoreWebApi;
using AspNetCoreWebApi.Filters;
using AspNetCoreWebApi.Indentity;
using AspNetCoreWebApi.JWT;
using AspNetCoreWebApi.MiddleWare;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region  使用依赖注入
builder.Services.AddScoped<Calculator>();
#endregion

#region 使用缓存
builder.Services.AddMemoryCache();
#endregion

#region  SwaggerUI中增加JWT验证
builder.Services.AddSwaggerGen(c =>
{
    var scheme = new OpenApiSecurityScheme
    {
        Description = "请输入token,格式为 Bearer xxxxxxxx",
        // Reference= new OpenApiReference() { Id= "Authorization" ,Type=ReferenceType.Schema},
        Scheme = "oauth2",
        Name = "Authorization", //标头名
        In = ParameterLocation.Header,  //表示头部
        Type = SecuritySchemeType.ApiKey,
    };
    //添加token验证
    c.AddSecurityDefinition("Authorization", scheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Authorization" }
            },
            new List<string>()
        }
    });

    //中文注释
    var basePath = Path.GetDirectoryName(AppContext.BaseDirectory);
    c.IncludeXmlComments(Path.Combine(basePath, "swagger.xml"), true);
});
#endregion 

#region redis配置
builder.Services.AddStackExchangeRedisCache(e =>
{
    e.Configuration = "127.0.0.1";
    e.InstanceName = "webname";
});
#endregion

#region 跨域访问控制
string[] urls = ["http://127.0.0.1:8081"];
builder.Services.AddCors(opt=>
        opt.AddDefaultPolicy(
            b=>b.WithOrigins(urls)
            //.AllowAnyOrigin() 
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials())
);
#endregion

#region 增加过滤器
//注册异常处理Filter
builder.Services.Configure<MvcOptions>(options =>
{
    options.Filters.Add<JwtVersionCheckFilter>();
    //options.Filters.Add<WebActionFilter>();
    // options.Filters.Add<WebExceptionFilter>();
});
#endregion

#region 注册Identity
//注册Identity
//builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<MyUser>();

builder.Services.AddDbContext<MyDbContext>(options=>
{
    options.UseSqlServer("Data Source=127.0.0.1;Database=Demo2;User Id=sa;Password=123456;Encrypt=false;");
});
builder.Services.AddDataProtection();
builder.Services.AddIdentityCore<MyUser>(options=>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.User.RequireUniqueEmail = true;
    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
    options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
    

});
    
IdentityBuilder idbuilder=new IdentityBuilder(typeof(MyUser),typeof(MyRole),builder.Services);

idbuilder.AddEntityFrameworkStores<MyDbContext>()
    .AddDefaultTokenProviders()
    .AddRoleManager<RoleManager<MyRole>>()
    .AddUserManager<UserManager<MyUser>>();

#endregion

#region 注册JWT配置 
//这里的顺序一定先注册Identity，否则Author属性不起作用

//注册JWT配置
//appsetting.json中配置JWT节点
builder.Services.Configure<JwtWebSettings>(builder.Configuration.GetSection("JWT"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    var jwtConfig = builder.Configuration.GetSection("JWT").Get<JwtWebSettings>();
    byte[] keyBytes = Encoding.UTF8.GetBytes(jwtConfig.SecurityKey);
    var securityKey = new SymmetricSecurityKey(keyBytes);
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = securityKey
    };

    #region 增加websocket身份认证
    options.Events = new JwtBearerEvents()
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/Hubs/ChatRoomHub")))
            {
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        }
    };
    #endregion
});


#endregion 


#region 增加验证框架

builder.Services.AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssembly(Assembly.GetEntryAssembly());
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
#region 跨域访问

//Cors原理：通过报文头中添加access-control-allow-orgin告诉浏览器跨域访问

//跨域访问需要在 app.UseHttpsRedirection();之前调用app.UseCors();
app.UseCors();
#endregion
app.UseHttpsRedirection();



#region 注册中间件
// app.UseMiddleware<MarkdownMiddleware>();
#endregion


//Swagger 中无法进行token验证需要加上
app.UseAuthentication();
app.UseAuthorization();

//启用服务器端缓存 必须在MapControllers之前，UseCors之后
//如果请求头中含有Cache-Control=no-cache则会忽略服务器端缓存
//相应状态为200的Get，Head可能被缓存POST请求是不能被缓存的；报文头中不能含有Authorization，Set-Cookie等。
app.UseResponseCaching();
app.MapControllers();

app.Run();


