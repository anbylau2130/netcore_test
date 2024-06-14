using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi.MediatR;

public class BaseDbContext : DbContext
{


    public DbSet<Material> Materials { get; set; }


    private readonly IMediator mediator;

    public BaseDbContext(IMediator mediator)
    {
        this.mediator = mediator;
    }

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
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="acceptAllChangesOnSuccess"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        //获取所有未发布事件的实体对象
        var domainEntites=this.ChangeTracker.Entries<IDomainEvents>().Where(e=>e.Entity.GetDomainEvents().Any());

        var domainEvents=domainEntites.SelectMany(x=>x.Entity.GetDomainEvents());

        foreach(var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);

        }

        domainEntites.ToList().ForEach(e => e.Entity.ClearDomainEvents());
        //把消息发布放到保存之前可以保证事务一致性
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}