# Factory

**Task:**

Create a factory for the [Product](FastestWaysInCSharp/Factory/Product.cs) object.

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.100-preview.1.22110.4
  [Host]     : .NET 7.0.0 (7.0.22.7608), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 7.0.0 (7.0.22.7608), X64 RyuJIT


```
|                              Method |      Mean |    Error |    StdDev | Ratio | RatioSD |  Gen 0 | Code Size | Allocated |
|------------------------------------ |----------:|---------:|----------:|------:|--------:|-------:|----------:|----------:|
|    ActivatorUtilities.CreateFactory |  61.79 ns | 1.234 ns |  2.287 ns |  0.36 |    0.02 | 0.0069 |     294 B |      88 B |
| ActivatorUtilities.CreateFactory&lt;T&gt; |  64.82 ns | 1.289 ns |  2.007 ns |  0.38 |    0.02 | 0.0069 |     172 B |      88 B |
|                                 New | 170.57 ns | 3.461 ns |  6.912 ns |  1.00 |    0.00 | 0.0293 |     307 B |     368 B |
|                        NaiveFactory | 172.40 ns | 3.480 ns |  7.639 ns |  1.01 |    0.06 | 0.0312 |     342 B |     392 B |
|   ActivatorUtilities.CreateInstance | 378.71 ns | 7.523 ns | 14.850 ns |  2.22 |    0.11 | 0.0157 |     304 B |     200 B |

## Sources

- https://github.com/davidfowl/DotNetCodingPatterns
