using System.Security.Claims;
using Hiuyeung.Common.Extentions.Jwt;

namespace GrpcToken.Apis;

public class TokenServiceImpl : ITokenService
{

    private readonly IConfiguration _configuration;

    public TokenServiceImpl(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetToken()
    {
        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.NameIdentifier, "1"));
        claims.Add(new Claim(ClaimTypes.Name, "admin"));
        claims.Add(new Claim("JwtVersion", "1"));
        string securityKey = _configuration.GetSection("JwtWebSettings:SecurityKey").Value;
        string expireSeconds = _configuration.GetSection("JwtWebSettings:ExpireSeconds").Value;
        var result = JwtTokenGenerator.GetToken(claims, securityKey, int.Parse(expireSeconds));
        return result;
    }
}