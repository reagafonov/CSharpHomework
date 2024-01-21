namespace RandomGame;

public interface INumberCheckChain
{
    bool Check(int number, int comparingNumber);

    void SetNext(INumberCheckChain chain);
}