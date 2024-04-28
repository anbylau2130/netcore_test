using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi.Indentity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
public class MyDbContext: IdentityDbContext<MyUser,MyRole,long>
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {

    }
}