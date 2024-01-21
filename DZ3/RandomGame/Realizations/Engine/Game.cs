using System.ComponentModel.Design;

namespace RandomGame;

public class Game : IGame
{
    //OCP
    private readonly IConsoleWriter _writer;
    private readonly IGameProcess _game;
     public Game(IConsoleWriter writer, IGameProcess game)
    {
        _writer = writer;
        _game = game;
    }

    public void Run()
    {
        do
        {
            _game.Play();
        } while (!_game.IsGameOver);

        if (_game.IsWin)
            _writer.Write("Вы выиграли");
        else
            _writer.Write("Вы проиграли");
    }
}