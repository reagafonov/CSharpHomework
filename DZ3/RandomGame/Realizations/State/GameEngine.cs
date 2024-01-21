namespace RandomGame;

public class GameEngine : IGameEngine
{
    private IGameState _currentActivity;

    public IGameState StateInit { get; }
    
    public IGameState StateCheckLoose { get; }
    
    public IGameState StateCheckWin { get; }

    public IGameState StateGetData { get; }
    
    public int MaxNumberOfTryings { get; set; }
    public int Tryings { get; set; }
    public int RandomNumber { get; set; }
    public int ReadNumber { get; set; }
    
    public bool IsGameOver => _currentActivity.IsGameOver;

    public bool IsWin => _currentActivity.IsWin;
    
    public GameEngine(IStateFactory factory)
    {
        StateInit = factory.CreateInitState(this);
        StateCheckLoose = factory.CreateCheckLooseState(this);
        StateGetData = factory.CreateGetDataState(this);
        StateCheckWin = factory.CreateCheckWinState(this);
        _currentActivity = StateInit;

    }

    public void Play()
    {
        _currentActivity.Go();
    }
    
    public void SetState(IGameState state)
    {
        _currentActivity = state;
    }
}