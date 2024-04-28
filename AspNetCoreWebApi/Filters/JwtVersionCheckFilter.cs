using System.Security.Claims;
using AspNetCoreWebApi.Indentity;
using AspNetCoreWebApi.JWT;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreWebApi.Filters;

public class JwtVersionCheckFilter : IAsyncActionFilter
{
    public readonly UserManager<MyUser> userManager;

    public JwtVersionCheckFilter(UserManager<MyUser> userManager)
    {
        this.userManager = userManager;
    }


    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {

        ControllerActionDescriptor ctrlActionDes = context.ActionDescriptor as ControllerActionDescriptor;

        if (ctrlActionDes == null || ctrlActionDes.MethodInfo.GetCustomAttributes(typeof(NotCheckJwtVersionAttribute), true).Any())
        {
            await next();
            return;
        }

        var claimJwtVersion = context.HttpContext.User.FindFirst("JwtVersion");
        var claimUserId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (claimJwtVersion == null || claimUserId == null)
        {
            context.Result = new ObjectResult("JwtVersionFilter异常，无法检测到Payload中的数据")
            {
                StatusCode = 400
            };
            return;
        }
        long jwtVersionFromClient = Convert.ToInt64(claimJwtVersion.Value);
        long userIdFromClient = Convert.ToInt64(claimUserId.Value);
        var user = await userManager.FindByIdAsync(userIdFromClient.ToString());
        if (user == null)
        {
            context.Result = new ObjectResult("用户不存在!")
            {
                StatusCode = 400
            };
            return;
        }

        if (jwtVersionFromClient < user.JwtVersion)
        {
            context.Result = new ObjectResult("客户端Jwt已过期")
            {
                StatusCode = 400
            };
            return;
        }
        await next();
    }
}