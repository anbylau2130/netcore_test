using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi.Identity.Identity;

public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<MyDbContext>
{
    public MyDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<MyDbContext> optionsBuilder = new();
        optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Database=Demo;User Id=sa;Password=123456;Trusted_Connection=True" 
                                    );
        return new MyDbContext(optionsBuilder.Options);
    }
}