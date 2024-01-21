namespace RandomGame;

public abstract class GameNumberCheckChainBase:INumberCheckChain
{
    protected INumberCheckChain? Next = null;
    
    public abstract bool Check(int number, int comparingNumber);

    public void SetNext(INumberCheckChain chain)
    {
        Next = chain;
    }
}