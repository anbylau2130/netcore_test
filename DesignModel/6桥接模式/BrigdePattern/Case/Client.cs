namespace BrigdePattern.Case;

public class Client
{
    public void Test()
    {
        MobileOS android = new Android();
        android.SetApplication(new Game());
        android.Run();
        android.SetApplication(new Notepad());
        android.Run();

        MobileOS hongmeng=new HongMeng();
        hongmeng.SetApplication(new Game());
        hongmeng.Run();
        hongmeng.SetApplication(new Notepad());
        hongmeng.Run();
    }
}