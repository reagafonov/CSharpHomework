namespace RandomGame;

public interface IGameProcess
{
    void Play();
    bool IsGameOver { get; }
    bool IsWin { get; }
}