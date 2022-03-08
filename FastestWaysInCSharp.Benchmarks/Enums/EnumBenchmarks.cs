using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using FastestWaysInCSharp.Enums;

namespace FastestWaysInCSharp.Benchmarks.Enums;

[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public class EnumBenchmarks
{
    private static readonly Fruits _apple = Fruits.Apple;

    #region ToString

    [BenchmarkCategory("ToString"), Benchmark(Baseline = true)]
    public string EnumToString() => _apple.ToString();

    [BenchmarkCategory("ToString"), Benchmark]
    public string ToStringFast() => _apple.ToStringFast();

    #endregion

    #region IsDefinedName

    [BenchmarkCategory("IsDefinedName"), Benchmark(Baseline = true)]
    public bool EnumIsDefinedName() => Enum.IsDefined(typeof(Fruits), nameof(Fruits.Apple));

    [BenchmarkCategory("IsDefinedName"), Benchmark]
    public bool ExtensionsIsDefinedName() => FruitsExtensions.IsDefined(nameof(Fruits.Apple));

    #endregion

    #region IsDefined

    [BenchmarkCategory("IsDefined"), Benchmark(Baseline = true)]
    public bool EnumIsDefined() => Enum.IsDefined(typeof(Fruits), _apple);

    [BenchmarkCategory("IsDefined"), Benchmark]
    public bool ExtensionsIsDefined() => FruitsExtensions.IsDefined(_apple);

    #endregion

    #region GetValues

    [BenchmarkCategory("GetValues"), Benchmark(Baseline = true)]
    public Fruits[] EnumGetValues() => Enum.GetValues<Fruits>();

    [BenchmarkCategory("GetValues"), Benchmark]
    public Fruits[] ExtensionsGetValues() => FruitsExtensions.GetValues();

    #endregion

    #region GetNames

    [BenchmarkCategory("GetNames"), Benchmark(Baseline = true)]
    public string[] EnumGetNames() => Enum.GetNames<Fruits>();

    [BenchmarkCategory("GetNames"), Benchmark]
    public string[] ExtensionsGetNames() => FruitsExtensions.GetNames();

    #endregion

    #region TryParse

    [BenchmarkCategory("TryParse"), Benchmark(Baseline = true)]
    public Fruits EnumTryParse() => Enum.TryParse("Second", ignoreCase: false, out Fruits result) ? result : default;

    [BenchmarkCategory("TryParse"), Benchmark]
    public Fruits ExtensionsTryParse() => FruitsExtensions.TryParse("Second", ignoreCase: false, out Fruits result) ? result : default;

    [BenchmarkCategory("TryParseIgnoreCase"), Benchmark(Baseline = true)]
    public Fruits EnumTryParseIgnoreCase() => Enum.TryParse("second", ignoreCase: true, out Fruits result) ? result : default;

    [BenchmarkCategory("TryParseIgnoreCase"), Benchmark]
    public Fruits ExtensionsTryParseIgnoreCase() => FruitsExtensions.TryParse("second", ignoreCase: true, out Fruits result) ? result : default;

    #endregion
}
