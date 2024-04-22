using AspNetCoreWebMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebMvc.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var model=new Person( "John", 30, true ,DateTime.Now);
            return View(model);
        }
    }
}
