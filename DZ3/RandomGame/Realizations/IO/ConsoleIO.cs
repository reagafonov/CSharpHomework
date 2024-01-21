namespace RandomGame;


public class ConsoleIO :  IConsoleReader, IConsoleWriter
{
    public int? ReadInt(string? message, int tryings)
    {
        
        for (var i = 0; i < tryings; i++)
        {
            Console.WriteLine(message);
            var nString = Console.ReadLine();
            if (int.TryParse(nString, out int n))
                return n;
            Console.WriteLine("Не удалось прочитать число");
        }
        return null;
    }
    
    public void Write(string s) => Console.WriteLine(s);
}