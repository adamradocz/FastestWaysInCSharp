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
|                              Method |            Mean |         Error |        StdDev | Code Size |  Gen 0 |  Gen 1 | Allocated |
|------------------------------------ |----------------:|--------------:|--------------:|----------:|-------:|-------:|----------:|
|          'Regex - Pattern matching' |       184.19 ns |      3.654 ns |      7.865 ns |     131 B |      - |      - |         - |
|  'RegexCompiled - Pattern matching' |        50.71 ns |      1.027 ns |      1.537 ns |     131 B |      - |      - |         - |
| 'RegexSourceGen - Pattern matching' |        46.57 ns |      0.957 ns |      1.821 ns |     142 B |      - |      - |         - |
|                                     |                 |               |               |           |        |        |           |
|                   'Regex - Startup' |    11,404.08 ns |    198.595 ns |    185.766 ns |     278 B | 1.0834 | 0.0305 |  13,664 B |
|           'RegexCompiled - Startup' | 1,374,943.19 ns | 22,655.551 ns | 20,083.556 ns |     278 B |      - |      - |  14,737 B |
|          'RegexSourceGen - Startup' |    10,741.40 ns |    153.559 ns |    143.640 ns |     282 B | 1.0071 | 0.0153 |  12,728 B |

## Sources

https://www.youtube.com/watch?v=WosEhlHATOk
