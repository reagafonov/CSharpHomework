namespace RandomGame;

public class GameStateCheckLoose:IGameState
{
    private readonly IGameEngineInternal _state;
    private readonly IConsoleWriter _writer;
    public bool IsGameOver { get; private set; } = false;
    public bool IsWin => false;

    public GameStateCheckLoose(IGameEngineInternal state, IConsoleWriter writer)
    {
        _state = state;
        _writer = writer;
    }

    public void Go()
    {
        if (_state.MaxNumberOfTryings <= _state.Tryings)
        {
            IsGameOver = true;
        }
        else
        {
            _writer.Write($"Осталось {_state.MaxNumberOfTryings - _state.Tryings} попыток");
            _state.Tryings++;
            _state.SetState(_state.StateGetData);
        }
    }
    
}