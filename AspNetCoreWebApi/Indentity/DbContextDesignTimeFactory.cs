using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AspNetCoreWebApi.Indentity;

public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<MyDbContext>
{
    public MyDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<MyDbContext> optionsBuilder = new();
        optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Database=Demo2;User Id=sa;Password=123456;Encrypt=false;");
        return new MyDbContext(optionsBuilder.Options);
    }
}