namespace RandomGame;

public class GameNumberChainLess:GameNumberCheckChainBase
{
    private readonly IConsoleWriter _writer;

    public GameNumberChainLess(IConsoleWriter writer)
    {
        _writer = writer;
    }

    public override bool Check(int number, int comparingNumber)
    {
        if (number < comparingNumber)
        {
            _writer.Write("Меньше");
            return false;
        }

        return Next is not null && Next.Check(number, comparingNumber);
    }
}