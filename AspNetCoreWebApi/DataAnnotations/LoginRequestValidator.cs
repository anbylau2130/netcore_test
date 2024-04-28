using AspNetCoreWebApi.Indentity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi.DataAnnotations;

/// <summary>
/// 登录参数验证类
/// </summary>
public class LoginRequestValidator : AbstractValidator<LoginRequest>
{

    #region 使用依赖注入查询数据库

    private readonly UserManager<MyUser> userManager;


    #endregion

    /// <summary>
    /// 
    /// </summary>
    public LoginRequestValidator(UserManager<MyUser> userManager)
    {
        this.userManager = userManager;
        RuleFor(x => x.UserName).NotNull().WithMessage("用户名不能为空")
            //使用依赖注入
            .MustAsync(async (x, _) => await userManager.FindByNameAsync(x) == null).WithMessage("用户名已存在");

        RuleFor(x => x.Password).NotNull().NotEmpty().Length(3,6).WithMessage("密码不能为空");
    }
}