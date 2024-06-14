namespace ITest;

public interface IDataProvider
{
    public IEnumerable<EmailInfo> GetEmailsToBeSend();
   
}