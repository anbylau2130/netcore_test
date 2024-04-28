using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace AspNetCoreWebApi.Identity.Identity;

public class MyDbContext:IdentityDbContext<MyUser,MyRole,long>
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {

    }
}