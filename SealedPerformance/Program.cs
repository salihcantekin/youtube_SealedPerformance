

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<BenchmarkTest>();

public class BenchmarkTest
{
    private readonly NonSealedClass _nonSealedInstance = new();
    private readonly SealedClass _sealedInstance = new();

    [Benchmark]
    public int NonSealedClassBenchmark()
    {
        return _nonSealedInstance.Calculate(5, 5);
    }

    [Benchmark]
    public int SealedClassBenchmark()
    {
        return _sealedInstance.Calculate(5, 5);
    }
}



// devirtualization

public sealed class SealedClass
{
    public int Calculate(int x, int y)
    {
        return x * y;
    }
}

public class NonSealedClass
{
    public virtual int Calculate(int x, int y)
    {
        return x + y;
    }
}