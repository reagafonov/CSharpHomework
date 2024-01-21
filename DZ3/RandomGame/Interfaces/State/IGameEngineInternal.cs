namespace RandomGame;

public interface IGameEngineInternal
{
    IGameState StateCheckLoose { get; }
    
    IGameState StateCheckWin { get; }
    
    IGameState StateGetData { get; }

    void SetState(IGameState state);
    
    int MaxNumberOfTryings { get; set; }
    
    int Tryings { get; set; }
    
    int RandomNumber { get; set; }
    
    int ReadNumber { get; set; }
}