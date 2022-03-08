# Enums

You can find the usage in the benchmark project.

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1566 (21H2)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.100-preview.1.22110.4
  [Host]     : .NET 7.0.0 (7.0.22.7608), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 7.0.0 (7.0.22.7608), X64 RyuJIT


```
|                       Method |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Allocated |
|----------------------------- |------------:|----------:|----------:|------:|-------:|----------:|
|                 EnumToString |  12.3068 ns | 0.1093 ns | 0.0969 ns |  1.00 | 0.0029 |      24 B |
|                 ToStringFast |   1.5313 ns | 0.0218 ns | 0.0182 ns |  0.12 |      - |         - |
|                              |             |           |           |       |        |           |
|            EnumIsDefinedName |  51.2374 ns | 1.0461 ns | 1.4665 ns |  1.00 |      - |         - |
|      ExtensionsIsDefinedName |   1.2237 ns | 0.0026 ns | 0.0023 ns |  0.02 |      - |         - |
|                              |             |           |           |       |        |           |
|                EnumIsDefined |  82.4178 ns | 0.3068 ns | 0.2562 ns | 1.000 | 0.0029 |      24 B |
|          ExtensionsIsDefined |   0.0354 ns | 0.0151 ns | 0.0141 ns | 0.000 |      - |         - |
|                              |             |           |           |       |        |           |
|                EnumGetValues | 444.1913 ns | 8.4163 ns | 7.4608 ns | 1.000 | 0.0200 |     168 B |
|          ExtensionsGetValues |   3.6460 ns | 0.1022 ns | 0.0956 ns | 0.008 | 0.0057 |      48 B |
|                              |             |           |           |       |        |           |
|                 EnumGetNames |  14.1832 ns | 0.1165 ns | 0.1033 ns |  1.00 | 0.0076 |      64 B |
|           ExtensionsGetNames |  10.2504 ns | 0.0907 ns | 0.0848 ns |  0.72 | 0.0076 |      64 B |
|                              |             |           |           |       |        |           |
|                 EnumTryParse |  42.1915 ns | 0.4345 ns | 0.4064 ns |  1.00 |      - |         - |
|           ExtensionsTryParse |  17.2635 ns | 0.0807 ns | 0.0674 ns |  0.41 |      - |         - |
|                              |             |           |           |       |        |           |
|       EnumTryParseIgnoreCase |  42.2580 ns | 0.0593 ns | 0.0526 ns |  1.00 |      - |         - |
| ExtensionsTryParseIgnoreCase |  22.9805 ns | 0.0351 ns | 0.0329 ns |  0.54 |      - |         - |

## Sources

https://andrewlock.net/netescapades-enumgenerators-a-source-generator-for-enum-performance/
