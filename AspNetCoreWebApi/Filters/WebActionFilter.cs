using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreWebApi.Filters
{


    /*
     * ActionFilter:程序发生异常时执行
     *
     1,IAsyncActionFilter

     2.在Program.cs中进行注册
       //注册异常处理Filter
       builder.Services.Configure<MvcOptions>(options =>
       {
           options.Filters.Add<WebActionFilter>();
       });
     */
    public class WebActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("开始执行！");

            ActionExecutedContext r = await next();
            if (r.Exception == null)
            {
                Console.WriteLine("执行成功！");
            }
            else
            {
                Console.WriteLine("执行失败");
            }

        }


    }
}
