using ITest;

namespace test;

public class MyEmailSender:IEmailSender
{
    public Task SendEmailAsync(string email, string title, string body)
    {
        Console.WriteLine($"发送邮件{email}-{title}-{body}");
        return Task.CompletedTask;
    }
}