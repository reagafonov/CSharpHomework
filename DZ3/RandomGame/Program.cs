// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RandomGame;
using Console = System.Console;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("application.json")
    .Build();
var collection = new ServiceCollection();

var result  = collection.AddScoped<IConsoleReader,ConsoleIO>()
    .AddScoped<IConsoleWriter,ConsoleIO>()
    .AddScoped<IGame, Game>()
    .AddScoped<IGameProcess,GameEngine>()
    .AddScoped<IStateFactory, StateFactory>()
    .AddScoped<INumberCheckChain,GameNumberCheckChainBase>(x=>
    {
        var writer = x.GetRequiredService<IConsoleWriter>();
        var numberCheckChainLess = new GameNumberChainLess(writer);
        var numberCheckChainMore = new GameNumberChainMore(writer);
        numberCheckChainLess.SetNext(numberCheckChainMore);
        return numberCheckChainLess;
    })
    .Configure<GameOptions>(x=>
    {
        configuration.GetSection("GameOptions").Bind(x);
    })
    .BuildServiceProvider(); 
    var game = result.GetRequiredService<IGame>();
    game.Run();