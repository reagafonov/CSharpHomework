// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

async Task<int> CountFileSpacesAsync(string fileName, CancellationToken token)
{
    var text =await File.ReadAllTextAsync(fileName, token);
    return text.Count(x => x == ' ');
}
async Task<int> CountSpacesAsync(string fileName1, string fileName2, string fileName3, CancellationToken token)
{
    var file1Task = CountFileSpacesAsync(fileName1, token);
    var file2Task = CountFileSpacesAsync(fileName2, token);
    var file3Task = CountFileSpacesAsync(fileName3, token);

    await Task.WhenAll(file1Task, file2Task, file3Task);
    return file1Task.Result + file2Task.Result + file3Task.Result;
}

async Task<int> CountSpacesInDirAsync(string directioryName, CancellationToken token)
{
    if (!Directory.Exists(directioryName))
        throw new DirectoryNotFoundException(directioryName);
    var tasks = Directory.GetFiles(directioryName).Select(x => CountFileSpacesAsync(x, token)).ToArray();

    await Task.WhenAll(tasks);
    return tasks.Sum(x=>x.Result);
}

var file1Name = "File1.txt";
var file2Name = "File2.txt";
var file3Name = "File3.txt";
int dirResult;
try
{
    CancellationToken token = default;
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    var result = await CountSpacesAsync(file1Name, file2Name, file3Name, token);
    stopWatch.Stop();
    Console.WriteLine($"Число пробелов в файлах {file1Name}, {file2Name} и {file3Name} = {result}. Время: {stopWatch.Elapsed}");
    Console.WriteLine("Введите название папки:");
    var name = Console.ReadLine();
    
    stopWatch.Start();
    dirResult = await CountSpacesInDirAsync(name, token);
    stopWatch.Stop();
    Console.WriteLine($"Число пробелов в файлах в директории {name} = {dirResult}. Время {stopWatch.Elapsed}");
}
catch (AggregateException e)
{
    foreach (var exception in e.InnerExceptions)
    {
        if (exception is DirectoryNotFoundException dirException)
        {
            WriteDirNotFound(dirException);
        }
        else
            Console.WriteLine(exception.Message);

        throw;
    }
}
catch (DirectoryNotFoundException e)
{
    WriteDirNotFound(e);
}

void WriteDirNotFound(DirectoryNotFoundException directoryNotFoundException)
{
    Console.WriteLine($"Директория {directoryNotFoundException.Message} не найдена");
}

