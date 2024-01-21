using Microsoft.Extensions.Options;

namespace RandomGame;

public class GameStateInit:IGameState
{
    private readonly IGameEngineInternal _game;
    private readonly IOptions<GameOptions> _options;
    private readonly IConsoleWriter _writer;

    
    public GameStateInit(IGameEngineInternal game, IOptions<GameOptions> options, IConsoleWriter writer)
    {
        _game = game;
        _options = options;
        _writer = writer;
    }

    public void Go()
    {
        var optionsValue = _options?.Value ?? throw new NullReferenceException(nameof(GameOptions));
        var valueMin = optionsValue.Min;
        var valueMax = optionsValue.Max;
        _game.RandomNumber = new Random().Next(valueMin, valueMax);
        _game.MaxNumberOfTryings = _options.Value.Tryings;
        _writer.Write("Игра: Угадай число");
        _writer.Write($"Угадайте число за {_game.MaxNumberOfTryings} попыток");
        _writer.Write($"Загаданное число от {valueMin} до {valueMax}");
        _game.SetState(_game.StateCheckLoose);
    }

    public bool IsGameOver => false;
    public bool IsWin => false;
}