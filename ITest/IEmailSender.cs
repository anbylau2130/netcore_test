namespace ITest;

public interface IEmailSender
{
    public  Task SendEmailAsync(string email,string title,string body);

}