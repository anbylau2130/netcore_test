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

#region  ʹ������ע��
builder.Services.AddScoped<Calculator>();
#endregion

#region ʹ�û���
builder.Services.AddMemoryCache();
#endregion

#region  SwaggerUI������JWT��֤
builder.Services.AddSwaggerGen(c =>
{
    var scheme = new OpenApiSecurityScheme
    {
        Description = "������token,��ʽΪ Bearer xxxxxxxx",
        // Reference= new OpenApiReference() { Id= "Authorization" ,Type=ReferenceType.Schema},
        Scheme = "oauth2",
        Name = "Authorization", //��ͷ��
        In = ParameterLocation.Header,  //��ʾͷ��
        Type = SecuritySchemeType.ApiKey,
    };
    //���token��֤
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

    //����ע��
    var basePath = Path.GetDirectoryName(AppContext.BaseDirectory);
    c.IncludeXmlComments(Path.Combine(basePath, "swagger.xml"), true);
});
#endregion 

#region redis����
builder.Services.AddStackExchangeRedisCache(e =>
{
    e.Configuration = "127.0.0.1";
    e.InstanceName = "webname";
});
#endregion

#region ������ʿ���
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

#region ���ӹ�����
//ע���쳣����Filter
builder.Services.Configure<MvcOptions>(options =>
{
    options.Filters.Add<JwtVersionCheckFilter>();
    //options.Filters.Add<WebActionFilter>();
    // options.Filters.Add<WebExceptionFilter>();
});
#endregion

#region ע��Identity
//ע��Identity
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

#region ע��JWT���� 
//�����˳��һ����ע��Identity������Author���Բ�������

//ע��JWT����
//appsetting.json������JWT�ڵ�
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

    #region ����websocket�����֤
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


#region ������֤���

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
#region �������

//Corsԭ��ͨ������ͷ�����access-control-allow-orgin����������������

//���������Ҫ�� app.UseHttpsRedirection();֮ǰ����app.UseCors();
app.UseCors();
#endregion
app.UseHttpsRedirection();



#region ע���м��
// app.UseMiddleware<MarkdownMiddleware>();
#endregion


//Swagger ���޷�����token��֤��Ҫ����
app.UseAuthentication();
app.UseAuthorization();

//���÷������˻��� ������MapControllers֮ǰ��UseCors֮��
//�������ͷ�к���Cache-Control=no-cache�����Է������˻���
//��Ӧ״̬Ϊ200��Get��Head���ܱ�����POST�����ǲ��ܱ�����ģ�����ͷ�в��ܺ���Authorization��Set-Cookie�ȡ�
app.UseResponseCaching();
app.MapControllers();

app.Run();


