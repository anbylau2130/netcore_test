using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Hiuyeung.Common.Extentions.Swagger;

public static class SwaggerExtentions
{
    public static IServiceCollection AddSwaggerAuthor(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            var scheme = new OpenApiSecurityScheme
            {
                Description = "请输入token,格式为 Bearer xxxxxxxx",
                // Reference= new OpenApiReference() { Id= "Authorization" ,Type=ReferenceType.Schema},
                Scheme = "oauth2",
                Name = "Authorization", //标头名
                In = ParameterLocation.Header,  //表示头部
                Type = SecuritySchemeType.ApiKey,
            };
            //添加token验证
            c.AddSecurityDefinition("Authorization", scheme);
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Authorization" }
                    },
                    new List<string>()
                }
            });

            //中文注释
            //var basePath = Path.GetDirectoryName(AppContext.BaseDirectory);
            //c.IncludeXmlComments(Path.Combine(basePath, "swagger.xml"), true);
        });
        return services;
    }
}