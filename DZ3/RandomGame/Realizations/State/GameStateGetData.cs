namespace RandomGame;

public class GameStateGetData:IGameState
{
    private readonly IGameEngineInternal _state;
    private readonly IConsoleReader _reader;

    public GameStateGetData(IGameEngineInternal state, IConsoleReader reader)
    {
        _state = state;
        _reader = reader;
    }

    public void Go()
    {
        var number = _reader.ReadInt("Введите число", 3);
        if (number.HasValue)
        {
            _state.ReadNumber = number.Value;
            _state.SetState(_state.StateCheckWin);
        }
    }

    public bool IsGameOver => false;
    public bool IsWin => false;
}