using AspNetCoreWebApi.Indentity;
using Microsoft.AspNetCore.Identity;

1.IndentityUser<Tkey>,IdentityRole<Tkey> ：TKey代表主键的类型。我们一般编写继承自
    IndentityUser和IdentityRole的自定义类，可以增加自定义字段

2.NUGET安装：
    Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -Version 2.2.0
3.创建继承自IdDbContext的DbContext类,
在Program.cs中
//注册Identity
builder.Services.AddDbContext<MyDbContext>(options=>
{
    options.UseSqlServer("Server=127.0.0.1;Database=Demo2;User=sa;Password=123456;TrustServerCertificate=True;MultipleActiveResultSets=true");
});
builder.Services.AddDataProtection();
builder.Services.AddIdentityCore<MyUser>(options=>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.User.RequireUniqueEmail = true;
});
    
IdentityBuilder idbuilder=new IdentityBuilder(typeof(MyUser),typeof(MyRole),builder.Services);
idbuilder.AddEntityFrameworkStores<MyDbContext>().AddDefaultTokenProviders()
    .AddUserManager<UserManager<MyUser>>().AddRoleManager<RoleManager<MyRole>>();
 
4.创建继承自IdDbContext类来操作数据库，不过框架中提供了RoleManager和UserManager类来简化数据库操作



5.部分方法的返回值为Task<IdentityResult>类型，查看IdentityResult的文档可以了解到该类型代表身份验证结果，包含是否成功、失败原因等信息。