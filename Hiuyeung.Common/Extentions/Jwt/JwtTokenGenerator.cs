using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hiuyeung.Common.Extentions.Jwt;


/// <summary>
/// JwtToken生成器
/// </summary>
public class JwtTokenGenerator
{
    public static string GetToken(List<Claim> claims, string securityKey, int expireSeconds)
    {
        DateTime expires = DateTime.Now.AddSeconds(expireSeconds);
        byte[] secBytes = Encoding.UTF8.GetBytes(securityKey);
        var secKey = new SymmetricSecurityKey(secBytes);
        var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(claims: claims, expires: expires, signingCredentials: credentials);
        string jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        return jwt;
    }

    public static string JwtDecode(string jwtStr)
    {
        jwtStr.Replace('-', '+').Replace('_', '/');

        switch (jwtStr.Length / 4)
        {
            case 2:
                jwtStr += "==";
                break;
            case 3:
                jwtStr += "=";
                break;
        }
        var bytes = Convert.FromBase64String(jwtStr);
        return Encoding.UTF8.GetString(bytes);
    }


    public static bool CheckoutToken(string token,string securityKey)
    {
        JwtSecurityTokenHandler tokenHandler = new();
        TokenValidationParameters valParam = new TokenValidationParameters();
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        valParam.IssuerSigningKey = symmetricSecurityKey;
        valParam.ValidateIssuer = false;
        valParam.ValidateAudience = false;
        ClaimsPrincipal claimsPrincpal = tokenHandler.ValidateToken(token, valParam, out SecurityToken secToken);

        foreach (var claim in claimsPrincpal.Claims)
        {
            Console.WriteLine($"{claim.Type}={claim.Value}");
        }
        return true;
    }
}