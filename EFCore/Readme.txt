1.安装Microsoft.EntityFrameworkCore.Tools 
2.安装Microsoft.EntityFrameworkCore.Sqlserver


生成迁移文件：使用 Add-Migration {name} 迁移的名称  
 (1)添加-OutputDir参数指定不同数据库放入不同的文件中
更新数据库： Update-database
（1）Update-database xxx  把数据库回滚到xxx版本，迁移脚本不动
（2）Remove-migration    删除最后一次的迁移脚本
（3）Script-Migration    生成迁移SQL代码。可以生辰版本D到版本F的SQL脚本  Script-Migration D F


如果使用Mysql数据库

3.安装 Pomelo.EntityFrameworkCore.MySql
4.安装 Npgsql.EntityFrameworkCore.PostgreSQL





项目整合


DbContext中不配置数据库连接，而是为DbContext增加一个DbContextOptions类型的构造数。
2、EFCore项目安装对应数据库的EFCore Provider
3、asp.net core项目引用EFCore项目，并且通过AddDbContext来注入DbContext及对DbContext进行配置。
4、Controller中就可以注入DbContext类使用了。
5、让开发环境的Add-Migration知道连接哪个数据库在EFCore项目中创建一个实现了IDesignTimeDbContextFactory的类.并且在CreateDbContext返回一个连接开发数据库的DbContext.

public MyDbContext CreateDbContext(stringl] args
{
DbContextOptionsBuilder<MyDbContext> builder = newDbContextOptionsBuilder<MyDbContext>();
//string connStr = Environment.GetEnvironmentVariable("ConnStr");
string connStr="Data Source=.;lnitial Catalog=demo666;IntegratedSecurity=SSPl;";
builder.UseSalServer(connStr);
MyDbContext ctx= new MyDbContext(builder.Options);
return ctX;
}
如果不在乎连接字符串被上传到Git，就可以把连接字符串直接写死到CreateDbContext;如果在乎，那么CreateDbContext里面很难读取到VS中通过简单的方法设置的环境变量，
所以必须把连接字符串配置到Windows的正式的环境变量中，然后再Environment.GetEnvironmentVariable读取。需要把EFCore项目设置为启动项
6、正常执行Add-Miqration、Update-Database迁移就行了。需要把EFCore项目设置为启动项目，并且在【程序包管理器控制台】中也要选中EFCore项目，
并且安装Microsoft.EntityFrameworkcore.Tools Microsoft.EntityFrameworkcore.SqlServer.
