namespace RandomGame;

public interface IGameState
{
    void Go();
    
    bool IsGameOver { get; }
    
    bool IsWin { get; }
}