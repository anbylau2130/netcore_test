using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Hiuyeung.Common.Extentions.Jwt
{
    public static class JwtServiceExtentions
    {

        public static IServiceCollection AddJwtService(this IServiceCollection services, IConfiguration configuration,string sectionName= "JwtWebSettings")
        {
            services.Configure<JwtWebSettings>(configuration.GetSection(sectionName));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                var jwtConfig = configuration.GetSection(sectionName).Get<JwtWebSettings>();
                byte[] keyBytes = Encoding.UTF8.GetBytes(jwtConfig.SecurityKey);
                var securityKey = new SymmetricSecurityKey(keyBytes);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, //是否验证Issuer
                    ValidateAudience = false, //是否验证Audience
                    ValidateLifetime = true,   //是否验证时效日期
                    ValidateIssuerSigningKey = true, //是否验证SigningKey
                    IssuerSigningKey = securityKey
                };
            });

            services.AddAuthorization();
            return services;
        }


        public static WebApplication UseJwtService(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            return app; 
        }


    }
}
