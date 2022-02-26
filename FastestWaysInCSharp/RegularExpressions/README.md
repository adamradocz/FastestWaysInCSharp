# Regular expressions

**Task:**

Validate an email address with Regex.

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.100-preview.1.22110.4
  [Host]     : .NET 7.0.0 (7.0.22.7608), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 7.0.0 (7.0.22.7608), X64 RyuJIT


```
|                Method |            Mean |         Error |        StdDev | Code Size |  Gen 0 |  Gen 1 | Allocated |
|---------------------- |----------------:|--------------:|--------------:|----------:|-------:|-------:|----------:|
|                 Regex |       177.08 ns |      3.566 ns |      7.522 ns |     131 B |      - |      - |         - |
|         RegexCompiled |        51.00 ns |      1.039 ns |      1.873 ns |     131 B |      - |      - |         - |
|        RegexSourceGen |        48.49 ns |      0.978 ns |      1.885 ns |     142 B |      - |      - |         - |
|                       |                 |               |               |           |        |        |           |
|          RegexStartup |    12,115.13 ns |    242.292 ns |    521.560 ns |     278 B | 1.0834 | 0.0305 |  13,664 B |
|  RegexCompiledStartup | 1,597,973.28 ns | 31,834.494 ns | 87,146.413 ns |     278 B |      - |      - |  14,737 B |
| RegexSourceGenStartup |    13,173.65 ns |    257.403 ns |    408.268 ns |     282 B | 1.0071 | 0.0153 |  12,728 B |


## Sources

