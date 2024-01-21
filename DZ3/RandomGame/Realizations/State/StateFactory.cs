using Microsoft.Extensions.Options;

namespace RandomGame;

public class StateFactory:IStateFactory
{
    private readonly IOptions<GameOptions> _options;
    private readonly IConsoleWriter _writer;
    private readonly IConsoleReader _reader;
    private readonly INumberCheckChain _numberCheckChain;
    

    public StateFactory(IOptions<GameOptions> options, IConsoleWriter writer, IConsoleReader reader, INumberCheckChain numberCheckChain)
    {
        _options = options;
        _writer = writer;
        _reader = reader;
        _numberCheckChain = numberCheckChain;
    }

    public IGameState CreateInitState(IGameEngineInternal engine)
    {
        return new GameStateInit(engine, _options, _writer);
    }

    public IGameState CreateCheckLooseState(IGameEngineInternal engine)
    {
        return new GameStateCheckLoose(engine, _writer);
    }

    public IGameState CreateGetDataState(IGameEngineInternal engine)
    {
        return new GameStateGetData(engine, _reader);
    }

    public IGameState CreateCheckWinState(IGameEngineInternal engine)
    {
        return new GameStateCheckWin(engine, _writer, _numberCheckChain);
    }
}