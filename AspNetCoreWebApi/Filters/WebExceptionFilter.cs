using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreWebApi.Filters;


/*
 * IAsyncExceptionFilter:程序发生异常时执行
 * 
 * 
 1,实现IAsyncExceptionFilter接口，注入IHostEnviroment
通过判断环境类型，进行异常处理

   ObjectResult objResult = new ObjectResult(new {code=500,message=msg});
   objResult.StatusCode = 500;
   context.Result = objResult;
   context.ExceptionHandled = true;
   return Task.CompletedTask;
2.在Program.cs中进行注册
   //注册异常处理Filter
   builder.Services.Configure<MvcOptions>(options =>
   {
       options.Filters.Add<WebExceptionFilter>();
   });
    
 */


public class WebExceptionFilter:IAsyncExceptionFilter
{
    private readonly IWebHostEnvironment hostEnv;

    public WebExceptionFilter(IWebHostEnvironment hostEnv)
    {
        this.hostEnv = hostEnv;
    }

    public Task OnExceptionAsync(ExceptionContext context)
    {
        string msg = string.Empty;
        //if (hostEnv.IsDevelopment())
        //{
        //    msg = context.Exception.ToString();
        //}
        //else
        //{
            msg = "服务器端发生未处理的异常";
        // }
        ObjectResult objResult = new ObjectResult(new {code=500,message=msg});
        context.Result = objResult;
        context.ExceptionHandled = true;
        return Task.CompletedTask;
    }
}