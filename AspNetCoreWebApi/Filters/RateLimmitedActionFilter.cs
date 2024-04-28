using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace AspNetCoreWebApi.Filters
{
    public class RateLimmitedActionFilter:IAsyncActionFilter
    {

        //builder.Services.AddMemoryCache();
        public readonly IMemoryCache memoryCache;

        public RateLimmitedActionFilter(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string ip = context.HttpContext.Connection.RemoteIpAddress.ToString();


            string cacheKey = $"LastVisitTick_{ip}";

            long? lastVisit = memoryCache.Get<long?>(cacheKey);
            if (lastVisit == null || Environment.TickCount64 - lastVisit > 1000)
            {
                memoryCache.Set(cacheKey, Environment.TickCount64, TimeSpan.FromTicks(10));
                await next();
            }
            else
            {
                ObjectResult result = new ObjectResult(new { code="429",message="访问太频繁" }) ;
                context.Result = result;
            }

        }
    }
}
