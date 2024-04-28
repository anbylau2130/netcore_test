namespace AspNetCoreWebApi.JWT;

/// <summary>
/// 不检测JwtVersion标识
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class NotCheckJwtVersionAttribute:Attribute
{
    
}