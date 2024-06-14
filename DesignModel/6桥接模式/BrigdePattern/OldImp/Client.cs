namespace BrigdePattern.OldImp;

public class Client
{
    public void Test()
    {
        Square redSquare = new RedSquare();
        redSquare.Draw();
        Square greenSquare = new GreenSquare();
        greenSquare.Draw();
    }
}