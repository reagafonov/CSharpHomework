// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;
using System.Diagnostics;


long SumThreadList(List<int> list, uint degree)
{
    var i = 0;
    var maxDegree = (int)degree;
    var resultList = Enumerable.Range(0,maxDegree).Select(x=>0).ToArray();
    var j = 0;
    var length = (int)(list.Count/ degree);
    
    var tasks = Enumerable.Range(0,maxDegree).Select(x => new Thread(() =>
    {
        var z = x;
        var min =(int)( z * degree);
        var max = (int)((z + 1) * degree);
        if (z == degree - 1)
            max = length;
        for(var i=min;i<max;i++)
            resultList[z] += list[i];
    })).ToList();
    foreach (var task in tasks)
    {
        task.Start();
    }
    foreach (var task in tasks)
    {
        task.Join();
    }

    return resultList.Sum();
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
}

void CheckTime(uint count, Action action, string name)
{
    var stopwatch = new Stopwatch();
    long ticks = 0;
    const int number = 10;
    for (int i = 0; i < number; i++)
    {
        stopwatch.Start();
        action();
        stopwatch.Stop();
        ticks += stopwatch.ElapsedTicks;
        stopwatch.Reset();
    }

    ticks /= number;
    Console.WriteLine($"{name}:{count}-{TimeSpan.FromTicks(ticks)}");
}


void CountThreadElements(uint count)
{
    var degree = 5u;
    var data = GenerateList(count);
    
    CheckTime(count, () => SumSimple(data), "Simple");
    CheckTime(count, () => SumThreadList(data, degree), "Thread");
    CheckTime(count, () => SumWithLinq(data,degree), "Linq");
}

Console.WriteLine($"OS-{Environment.OSVersion}");
Console.WriteLine($"Processors-{Environment.ProcessorCount}");
CountThreadElements(100_000);
CountThreadElements(1_000_000);
CountThreadElements(10_000_000);

