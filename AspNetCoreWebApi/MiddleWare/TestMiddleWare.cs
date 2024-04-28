namespace AspNetCoreWebApi.MiddleWare;

public class TestMiddleWare
{
    public readonly RequestDelegate next;
    public TestMiddleWare(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        context.Response.WriteAsync("1111111111");
        await next.Invoke(context);
    }
}