namespace RandomGame;

public interface IStateFactory
{
    IGameState CreateInitState(IGameEngineInternal engine);
    IGameState CreateCheckLooseState(IGameEngineInternal engine);
    IGameState CreateGetDataState(IGameEngineInternal engine);
    IGameState CreateCheckWinState(IGameEngineInternal engine);
}