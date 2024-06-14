namespace ITest;

public class Bussiness
{
    private readonly IEmailSender emailSender;
    private readonly IDataProvider provider;

    public Bussiness(IEmailSender emailSender, IDataProvider provider)
    {
        this.emailSender = emailSender;
        this.provider = provider;
    }

    public async Task Send()
    {
        var emailInfos=provider.GetEmailsToBeSend();
        foreach (var email in emailInfos)
        {
            await emailSender.SendEmailAsync(email.Email, email.Title, email.Body);
        }
    }
}