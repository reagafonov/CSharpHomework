// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;
using System.Diagnostics;

void SumParallel(int i, uint ucount, List<int> data, Barrier barrier)
{
    var count = (int)ucount;
    if (barrier == null)
        throw new NullReferenceException(nameof(barrier));
    var dataLengh = data.Count;

    while (dataLengh > 1)
    {
        var isLast = count == i;
        int result=0;
        if (i <= count)
        {
            var currentLength = dataLengh / count;

            var min = i * count;
            var max = isLast ? dataLengh : (i + 1) * currentLength - 1;
            result = data.Skip(min).Take(max - min).Sum();
        }

        barrier.SignalAndWait();
        if (i <= count)
        {
            data[i] = result;
            if (i == 0)
            {
                if (dataLengh % 2 == 1)
                    data[dataLengh - 1] += data[dataLengh - 2];
                dataLengh /= 2;
                count /= 2;
                count = Math.Max(count, 1);
            }
        }

        barrier.SignalAndWait();
    }
}

int Sum(List<int> list, uint count)
{
    var resultList = list.ToList();
    int i = 0;
    var barrier = new Barrier((int)count);
    var j = 0;
    var threads = Enumerable.Range(0,(int)count-1)
        .Select(x => new Thread(() => SumParallel(j++,count,resultList, barrier)))
        .ToList();
    foreach (var thread in threads)
    {
        thread.Start();
    }

    foreach (var thread in threads)
    {
        thread.Join();
    }

    return resultList.First();
}

double SumThreadList(List<double> list, uint count)
{
    var i = 0;
    var concurrentBag = new ConcurrentBag<double>();
    var groups = list.GroupBy(x => i++ % count).Select(x=>x.ToList()).ToList();
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


double SumWithLinq(List<double> data, uint count)
{
    return data.AsParallel().Sum();
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
