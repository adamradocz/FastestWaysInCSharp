# Enums

You can find the usage in the benchmark project.

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1566 (21H2)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100-preview.1.22110.4
  [Host]     : .NET 7.0.0 (7.0.22.7608), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 7.0.0 (7.0.22.7608), X64 RyuJIT


```
|                       Method |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |------------:|----------:|----------:|------------:|------:|--------:|-------:|----------:|
|                 EnumToString |  16.8614 ns | 0.4142 ns | 0.9263 ns |  16.6442 ns |  1.00 |    0.00 | 0.0057 |      24 B |
|                 ToStringFast |   1.8048 ns | 0.1056 ns | 0.1734 ns |   1.8346 ns |  0.11 |    0.01 |      - |         - |
|                              |             |           |           |             |       |         |        |           |
|            EnumIsDefinedName | 109.0442 ns | 2.0711 ns | 2.9704 ns | 108.2193 ns | 1.000 |    0.00 | 0.0057 |      24 B |
|      ExtensionsIsDefinedName |   0.0091 ns | 0.0137 ns | 0.0128 ns |   0.0000 ns | 0.000 |    0.00 |      - |         - |
|                              |             |           |           |             |       |         |        |           |
|                EnumIsDefined | 109.8621 ns | 1.3623 ns | 1.1376 ns | 109.8714 ns | 1.000 |    0.00 | 0.0057 |      24 B |
|          ExtensionsIsDefined |   0.0042 ns | 0.0082 ns | 0.0072 ns |   0.0000 ns | 0.000 |    0.00 |      - |         - |
|                              |             |           |           |             |       |         |        |           |
|                EnumGetValues | 573.0048 ns | 6.5971 ns | 5.8481 ns | 572.2688 ns | 1.000 |    0.00 | 0.0401 |     168 B |
|          ExtensionsGetValues |   5.0030 ns | 0.1065 ns | 0.0997 ns |   5.0259 ns | 0.009 |    0.00 | 0.0115 |      48 B |
|                              |             |           |           |             |       |         |        |           |
|                 EnumGetNames |  18.9062 ns | 0.4245 ns | 0.3763 ns |  18.8923 ns |  1.00 |    0.00 | 0.0153 |      64 B |
|           ExtensionsGetNames |  12.6532 ns | 0.2056 ns | 0.1823 ns |  12.6932 ns |  0.67 |    0.01 | 0.0153 |      64 B |
|                              |             |           |           |             |       |         |        |           |
|                 EnumTryParse |  57.0789 ns | 0.7750 ns | 0.7249 ns |  56.9494 ns |  1.00 |    0.00 |      - |         - |
|           ExtensionsTryParse |  19.3221 ns | 0.3802 ns | 0.3556 ns |  19.2651 ns |  0.34 |    0.01 |      - |         - |
|                              |             |           |           |             |       |         |        |           |
|       EnumTryParseIgnoreCase |  56.7264 ns | 1.1252 ns | 1.1051 ns |  56.7234 ns |  1.00 |    0.00 |      - |         - |
| ExtensionsTryParseIgnoreCase |  30.0813 ns | 0.6370 ns | 1.0465 ns |  29.6373 ns |  0.53 |    0.02 |      - |         - |

## Sources

https://andrewlock.net/netescapades-enumgenerators-a-source-generator-for-enum-performance/
