// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;
using System.Diagnostics;


long SumThreadList(List<int> list, uint degree)
{
    var i = 0;
    var concurrentBag = new ConcurrentBag<long>();
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

List<int> GenerateList(uint count)
{
    var data = new List<int>();
    for (int i = 0; i < count; i++)
    {
        data.Add(Random.Shared.Next(-1,1));
    }

    return data;
}


long SumWithLinq(List<int> data, uint degree)
{
    return data.AsParallel().WithDegreeOfParallelism((int)degree).Sum();
}

long SumSimple(List<int> data)
{
    long resut = 0;
    foreach (var element in data)
    {
        resut += element;
    }

    return resut;
};

void CountThreadElements(uint count)
{
    var degree = 5u;
    var data = GenerateList(count);
    var stopwatch = new Stopwatch();
    stopwatch.Start();
    SumSimple(data);
    stopwatch.Stop();
    Console.WriteLine($"Simple:{count}-{stopwatch.Elapsed}");
    stopwatch.Reset();
    stopwatch.Start();
    var result = SumThreadList(data, degree);
    stopwatch.Stop();
    stopwatch.Reset();
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
