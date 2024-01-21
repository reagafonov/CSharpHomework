namespace RandomGame;

public class GameNumberChainMore:GameNumberCheckChainBase
{
    private readonly IConsoleWriter _writer;

    public GameNumberChainMore(IConsoleWriter writer)
    {
        _writer = writer;
    }

    public override bool Check(int number, int comparingNumber)
    {
        if (number > comparingNumber)
        {
            _writer.Write("Больше");
            return false;
        }

        return Next is not null && Next.Check(number, comparingNumber);
    }
}