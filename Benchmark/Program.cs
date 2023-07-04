namespace Benchmark;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Perfolizer.Mathematics.Randomization;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<Benchmark>();
    }
}

[SimpleJob]
[RPlotExporter]
public class Benchmark
{
    [Params(1000, 10000)]
    public int N;

    private List<double> list=new();

    [GlobalSetup]
    public void Setup()
    {
        Shuffler shuffler = new();
        list = new(Enumerable.Range(-N, N * 2).Select(x => (double)x));
        shuffler.Shuffle(list);
    }

    [Benchmark]
    public double OrderByFirst() => list.OrderBy(x => x).First();

    [Benchmark]
    public double MinBy() => list.MinBy(x => x);

    [Benchmark]
    public double OrderByDescendingLast() => list.OrderByDescending(x => x).Last();

    [Benchmark]
    public double OrderByDescendingFirst() => list.OrderByDescending(x => x).First();

    [Benchmark]
    public double MaxBy() => list.MaxBy(x => x);

    [Benchmark]
    public double OrderByLast() => list.OrderBy(x => x).Last();
}
