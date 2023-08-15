// See https://aka.ms/new-console-template for more information

using System;
using System.Collections;
using System.Linq;
using System.Text;
using DZ17;
using DZ17.Files;
using DZ17.GenericDelegate;

void PrintEnumerator(IEnumerable elements)
{
    var enumerator = elements.GetEnumerator();
    while (true)
    {
        for (var i = 0; i < 10; i++)
        {
            if (!enumerator.MoveNext())
            {
                Console.WriteLine();
                return;
            }
            Console.Write($"\"{enumerator.Current}\"");
            Console.Write("\t| ");
        }

        Console.WriteLine();
    }
}

var random = new Random();
var elements = Enumerable.Range(1, 325).Select(x => random.Next(0,1000).ToString());
static float GetValue(string element) => float.TryParse(element, out var result) ? result : default;

Console.WriteLine("Элементы:");
PrintEnumerator(elements);
Console.WriteLine("Максимальное значение");
var max = elements.GetMax<string>(GetValue);
Console.WriteLine(max);

var fileSearcher = new ScanFileSystem();
using var fileSearcherToConsole1 = new FileSearcherToConsole(random.Next(50), fileSearcher, "1");
using var fileSearcherToConsole2 = new FileSearcherToConsole(random.Next(50), fileSearcher, "2");
if (OperatingSystem.IsWindows())
    fileSearcher.Scan("C:");
else
{
    fileSearcher.Scan("/");
}



