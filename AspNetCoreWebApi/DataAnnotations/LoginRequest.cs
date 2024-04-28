namespace AspNetCoreWebApi.DataAnnotations;

/// <summary>
/// Login方法Request参数
/// </summary>
/// <param name="UserName">用户名</param>
/// <param name="Password">密码</param>
public record LoginRequest(string UserName,string Password);
