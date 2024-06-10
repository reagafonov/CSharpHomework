// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;
using System.Diagnostics;


double SumThreadList(List<double> list, uint degree)
{
    var i = 0;
    var concurrentBag = new ConcurrentBag<double>();
    var groups = list.GroupBy(x => i++ % degree).Select(x=>x.ToList()).ToList();
    var tasks = groups.Select(x => new Thread(() => concurrentBag.Add(x.Sum()))).ToList();
    foreach (var task in tasks)
    {
        task.Start();
    }
    foreach (var task in tasks)
    {
        task.Join();
    }

    return concurrentBag.Sum();
}

List<double> GenerateList(uint count)
{
    var data = new List<double>();
    for (int i = 0; i < count; i++)
    {
        data.Add(Random.Shared.Next());
    }

    return data;
}


double SumWithLinq(List<double> data, uint degree)
{
    return data.AsParallel().WithDegreeOfParallelism((int)degree).Sum();
}

double SumSimple(List<double> data)
{
    double resut = 0;
    foreach (var element in data)
    {
        resut += element;
    }

    return resut;
};

void CountThreadElements(uint count)
{
    var degree = 3u;
    var data = GenerateList(count);
    var stopwatch = new Stopwatch();
    stopwatch.Start();
    SumSimple(data);
    stopwatch.Stop();
    Console.WriteLine($"Simple:{count}-{stopwatch.Elapsed}");
    stopwatch.Start();
    var result = SumThreadList(data, degree);
    stopwatch.Stop();
    Console.WriteLine($"Thread:{count}-{stopwatch.Elapsed}");
    stopwatch.Start();
    var result2 = SumWithLinq(data,degree);
    stopwatch.Stop();
    Console.WriteLine($"Linq:{count}-{stopwatch.Elapsed}");
}

Console.WriteLine($"OS-{Environment.OSVersion}");
Console.WriteLine($"Processors-{Environment.ProcessorCount}");
CountThreadElements(1_000_000);
CountThreadElements(10_000_000);
CountThreadElements(100_000_000);
