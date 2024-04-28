using System.IO;
using System.Text;
using Ude;

namespace AspNetCoreWebApi.MiddleWare;

/// <summary>
/// 中间件
/// 用于处理markdown文件
/// 依赖Ude net standard包,MarkdownSharp包
/// 使用方法：在Startup.cs中添加中间件：
/// app.UseMiddleware<MarkdownMiddleware>();
/// </summary>
public class MarkdownMiddleware
{
    public readonly RequestDelegate next;
    public readonly IWebHostEnvironment hostEnv;
    public MarkdownMiddleware(RequestDelegate next, IWebHostEnvironment hostEnv)
    {
        this.next = next;
        this.hostEnv = hostEnv;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string path = context.Request.Path.ToString();
        var file = hostEnv.WebRootFileProvider.GetFileInfo(path);
        if (!file.Exists && !path.EndsWith(".md"))
        {
            await next.Invoke(context);
            return;
        }

        using (var steam = file.CreateReadStream())
        {
            string charset = DetectCharset(steam);
            steam.Position = 0;
            using (var reader = new StreamReader(steam, Encoding.GetEncoding(charset)))
            {
                string markdown = await reader.ReadToEndAsync();
                string html = MarkdownToHtmlConverter(markdown);
                context.Response.ContentType = "text/html;charset=UTF-8";
                await context.Response.WriteAsync(html);
            }
        }
    }

    /// <summary>
    /// 安装ude net standard包 
    /// 检测流的字符集编码
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    private string DetectCharset(Stream stream)
    {
        CharsetDetector charDetector = new CharsetDetector();
        charDetector.Feed(stream);
        charDetector.DataEnd();
        string charset = charDetector.Charset ?? "UTF-8";
        return charset;
    }

    private string MarkdownToHtmlConverter(string markdown)
    {
        //TODO: markdown to html converter
        MarkdownSharp.Markdown markdownSharp = new MarkdownSharp.Markdown();
        string html = markdownSharp.Transform(markdown);
        return html;
    }

}