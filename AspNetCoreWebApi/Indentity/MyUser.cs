using Microsoft.AspNetCore.Identity;

namespace AspNetCoreWebApi.Indentity;

public class MyUser:IdentityUser<long>
{
    public  int JwtVersion { get; set; }
}