namespace RandomGame;

public class GameStateCheckWin:IGameState
{
    private readonly IGameEngineInternal _state;
    private readonly INumberCheckChain _head;
    private readonly IConsoleWriter _writer;
    private bool _isGameOver = false;

    public GameStateCheckWin(IGameEngineInternal state, IConsoleWriter writer, INumberCheckChain head)
    {
        _state = state;
        _writer = writer;
        _head = head;
    }

    public void Go()
    {
        var stateReadNumber = _state.ReadNumber;
        var stateNumber = _state.RandomNumber;
        if (stateReadNumber == stateNumber)
        {
            _writer.Write("Совпало");
            _isGameOver = true;
            return;
        }

        _head.Check( stateNumber,stateReadNumber);
        _state.SetState(_state.StateCheckLoose);
    }

    public bool IsGameOver => _isGameOver;
    public bool IsWin => true;
}