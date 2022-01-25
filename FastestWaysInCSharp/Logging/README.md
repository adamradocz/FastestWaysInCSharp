# Improving logging performance

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1469 (21H2)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                             Method |      Mean |     Error |    StdDev | Ratio | Code Size |  Gen 0 | Allocated |
|----------------------------------- |----------:|----------:|----------:|------:|----------:|-------:|----------:|
|     StructuredLoggingLevelChecking |  4.085 ns | 0.0023 ns | 0.0018 ns |  0.07 |     165 B |      - |         - |
|       LoggerMessageSourceGenerator |  4.360 ns | 0.0019 ns | 0.0016 ns |  0.07 |     121 B |      - |         - |
| LoggerMessageStaticSourceGenerator |  4.360 ns | 0.0011 ns | 0.0009 ns |  0.07 |     121 B |      - |         - |
|                 LoggerHelperDefine |  5.139 ns | 0.0071 ns | 0.0066 ns |  0.08 |      39 B |      - |         - |
|                  StructuredLogging | 60.927 ns | 0.0970 ns | 0.0908 ns |  1.00 |     136 B | 0.0038 |      32 B |
|                StringInterpolation | 75.319 ns | 0.3969 ns | 0.3712 ns |  1.24 |     351 B | 0.0191 |     160 B |

## Sources

- https://andrewlock.net/exploring-dotnet-6-part-8-improving-logging-performance-with-source-generators/
