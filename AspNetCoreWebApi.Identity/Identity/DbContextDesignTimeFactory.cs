using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi.Identity.Identity;

public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<MyDbContext>
{
    public MyDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<MyDbContext> optionsBuilder = new();
        optionsBuilder.UseSqlServer("Data Source=10.1.2.51;Database=Demo;User Id=wsdd;Password=hxn_db_wsdd;Trusted_Connection=True" 
                                    );
        return new MyDbContext(optionsBuilder.Options);

    }
}