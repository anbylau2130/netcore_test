using AspNetCoreWebApi.Identity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Identity.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {

        public readonly UserManager<MyUser> userManager;
        public readonly RoleManager<MyRole> roleManager;

        public TestController(UserManager<MyUser> userManager, RoleManager<MyRole> roleManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpGet]
       public async Task<string> AddUser()
       {
          var result=await   userManager.CreateAsync(new MyUser(){UserName = "hiuyeung"});
          if(result.Succeeded)
          {
                return "ok";
          }
            return "fail";
       }
    }
}
