using ITest;

namespace test;

public class MyDataProvider:IDataProvider
{
    public IEnumerable<EmailInfo> GetEmailsToBeSend()
    {
        string[] allLines = File.ReadAllLines("D:\\DEMO\\VSCode\\UspCore\\test\\email.txt");
        foreach (string line in allLines)
        {
            var section=line.Split(',');
            var name = section[0];
            var email= section[1];
            var title= section[2];
            var body= section[3];
            yield return new EmailInfo(email, title, body);
        }
    }
}