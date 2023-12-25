# Regular expressions

**Task:**

Validate an email address with Regex.

```

BenchmarkDotNet v0.13.11, Windows 11 (10.0.22621.2861/22H2/2022Update/SunValley2)
11th Gen Intel Core i7-11370H 3.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method                              | Mean      | Error    | StdDev   | Code Size | Allocated |
|------------------------------------ |----------:|---------:|---------:|----------:|----------:|
| &#39;Regex - Pattern matching&#39;          | 105.25 ns | 0.274 ns | 0.256 ns |     129 B |         - |
| &#39;RegexCompiled - Pattern matching&#39;  |  59.57 ns | 0.223 ns | 0.209 ns |     129 B |         - |
| &#39;RegexSourceGen - Pattern matching&#39; |  50.86 ns | 0.226 ns | 0.200 ns |     129 B |         - |

## Sources

https://www.youtube.com/watch?v=WosEhlHATOk
