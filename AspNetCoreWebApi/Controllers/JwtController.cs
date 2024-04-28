using System.Security.Claims;
using AspNetCoreWebApi.DataAnnotations;
using AspNetCoreWebApi.Indentity;
using AspNetCoreWebApi.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetCoreWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JwtController : ControllerBase
    {

        public readonly UserManager<MyUser> userManage;
        public readonly RoleManager<MyRole> roleManage;
        public readonly IOptionsSnapshot<JwtWebSettings> jwtConfig;

        public JwtController(UserManager<MyUser> userManage, RoleManager<MyRole> roleManage, IOptionsSnapshot<JwtWebSettings> jwtConfig)
        {
            this.userManage = userManage;
            this.roleManage = roleManage;
            this.jwtConfig = jwtConfig;
        }

        
       /// <summary>
       /// 登录获取JwtToken
       /// </summary>
       /// <param name="username">用户名</param>
       /// <param name="password">密码</param>
       /// <returns></returns>
        [HttpPost]
        [NotCheckJwtVersion]
        public async Task<ActionResult<string>> Login(LoginRequest loginRequest)
        {
            var user = await userManage.FindByNameAsync(loginRequest.UserName);
            var isSuccess = await userManage.CheckPasswordAsync(user, loginRequest.Password);
            if (!isSuccess)
            {
                return BadRequest("账户名或密码错误");
            }
            #region 撤回jwt操作 jwtversion+1
            user.JwtVersion++;
            await userManage.UpdateAsync(user);
            #endregion 

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));

            #region 撤回jwt操作 增加令牌信息
            claims.Add(new Claim("JwtVersion", user.JwtVersion.ToString()));
            #endregion 

            var roles = await userManage.GetRolesAsync(user);
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            string jwtToken = Jwt.GetToken(claims, jwtConfig.Value.SecurityKey, jwtConfig.Value.ExpireSeconds);
            return jwtToken;
        }

        /// <summary>
        /// 测试权限接口
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public string AuthorizeTest()
        {
            //通过Claim获取用户名 
            var result=this.User.FindFirst(ClaimTypes.NameIdentifier);
            return "1111111111112222222222";

        }
    }
}
