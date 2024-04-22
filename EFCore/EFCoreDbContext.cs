using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCore;

public class EFCoreDbContext : DbContext
{
    //指定要绑定的实体类
    public DbSet<Book> Books { get; set; }

    #region  一对多
    //两边都要配置导航属性
    public DbSet<Article> Articles { get; set; }
    public DbSet<Comment> Comments { get; set; }
    #endregion

    #region 反向导航
    //只在一方配置导航属性
    public DbSet<User> Users { get; set; }
    public DbSet<Leave> Leaves { get; set; }
    #endregion

    #region 自关联
    //父子节点的关系配置
    public DbSet<Node> Nodes { get; set; }
    #endregion

    #region 一对一
    public DbSet<Person> Persons { get; set; }
    public DbSet<PersonCard> PersonCards { get; set; }
    #endregion

    #region 多对多

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }

    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        //设置连接字符串
        string dbConnectionString =
            "Server=127.0.0.1;Database=Demo;User=sa;Password=123456;TrustServerCertificate=True;MultipleActiveResultSets=true";
        //使用sqlserver作为数据库
        optionsBuilder.UseSqlServer(dbConnectionString);
        //使用Mysql作为数据库
        //optionsBuilder.UseMySql("Server=.;Database=Demo;User=sa;Password=123456",new MySqlServerVersion(new Version(5,6,0)));
        //optionsBuilder.UseNpgsql("Server=.;Database=Demo;User=sa;Password=123456");
        optionsBuilder.LogTo(Console.WriteLine);
        optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //指定实体程序集
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}