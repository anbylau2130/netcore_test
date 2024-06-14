using EFCoreDDDTest.DDD;
using EFCoreDDDTest.DDDAggregation;
using EFCoreDDDTest.DDDEnum;
using EFCoreDDDTest.DDDValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreDDDTest;

public class AppDbContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    public DbSet<Shop> Shops { get; set; }

    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Material> Materials { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        string dbConnectionString = "Server=127.0.0.1;Database=DDDTest;User=sa;Password=123456;TrustServerCertificate=True;MultipleActiveResultSets=true";
        optionsBuilder.UseSqlServer(dbConnectionString);
        optionsBuilder.LogTo(Console.WriteLine);
        optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}