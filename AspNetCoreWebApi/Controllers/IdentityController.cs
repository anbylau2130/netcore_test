using AspNetCoreWebApi.Indentity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        public readonly UserManager<MyUser> userManager;
        public readonly RoleManager<MyRole> roleManager;

        public IdentityController(UserManager<MyUser> userManager, RoleManager<MyRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        /// <summary>
        /// 创建用户名为administrator的用户，并赋予admin权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> CreateAdmin()
        {
            if (await roleManager.RoleExistsAsync("admin") == false)
            {
                MyRole role = new MyRole() { Name = "admin" };
                var result = await roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    return BadRequest("Role CreateAsync fail");
                }
            }
            MyUser user = await userManager.FindByNameAsync("administrator");
            if (user == null)
            {
                user = new MyUser() { UserName = "administrator", Email = "190241347@qq.com" };
                var result = await userManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    return BadRequest("User CreateAsync fail");
                }
            }

            if (!await userManager.IsInRoleAsync(user, "admin"))
            {
                var result = await userManager.AddToRoleAsync(user, "admin");
                if (!result.Succeeded)
                {
                    return BadRequest("User AddToRoleAsync fail");
                }
            }


            return "ok";
        }

        /// <summary>
        /// 通过用户名获取重置密码token
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> SendResetPasswordToken(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return BadRequest("用户名不存在!");
            }
            string result = await userManager.GeneratePasswordResetTokenAsync(user);
            return Ok(result);
        }


        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="token">重置密码token</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ResetPassword(string username, string token, string newPassword)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return BadRequest("用户名不能为空");
            }
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("token不能为空");
            }
            var result = await userManager.ResetPasswordAsync(user, token, newPassword);
            if (result.Succeeded)
            {
                await userManager.ResetAccessFailedCountAsync(user);
                return Ok("密码初始化成功");
            }
            await userManager.AccessFailedAsync(user);
            var errorStr = string.Empty;
            foreach (var item in result.Errors)
            {
                errorStr += item.Description;
            }
            return BadRequest(errorStr);

        }



    }
}
