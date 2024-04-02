// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;
using System.Diagnostics;
using ThreadState = System.Threading.ThreadState;

List<int> GenerateList(int count)
{
    var data = new List<int>();
    for (int i = 0; i < count; i++)
    {
        data.Add(Random.Shared.Next());
    }

    return data;
}

long CountElements(IEnumerable<int> data) => data.Sum();
long CountWithThread(List<int> data, int threads)
{
    ConcurrentBag<long> bag = new();
    
    int i = 0;
    var groupping = data.GroupBy(x => i++ % threads).ToList()
        .Select(x=>new Thread(()=>bag.Add(x.Sum()))).ToList();
    foreach (var thread in groupping)
    {
        thread.Start();
    }

    while (groupping.Any(x=>x.ThreadState == ThreadState.Running))
    {
        Thread.SpinWait(1);
    }

    return bag.Sum();
}

long CountWithLinq(List<int> data)
{
    return data.AsParallel()
        //.AsUnordered()
        //.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
        .Sum();
}

void CountThreadElements(int count)
{
    var data = GenerateList(count);
    var stopwatch = new Stopwatch();
    stopwatch.Start();
    //var result = CountWithThread(data, 10);
    stopwatch.Stop();
    //Console.WriteLine($"Thread:{stopwatch.Elapsed}-{result}");
    stopwatch.Start();
    var result2 = CountWithLinq(data);
    stopwatch.Stop();
    Console.WriteLine($"Linq:{stopwatch.Elapsed}- {result2}");
}

Console.WriteLine($"OS-{Environment.OSVersion}");
Console.WriteLine($"Processors-{Environment.ProcessorCount}");
CountThreadElements(100_000);
CountThreadElements(1_000_000);
CountThreadElements(10_000_000);
