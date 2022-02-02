# Factory

**Task:**

Create a factory for the [Product](FastestWaysInCSharp/Factory/Product.cs) object.

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1469 (21H2)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                            Method |      Mean |    Error |   StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Allocated |
|---------------------------------- |----------:|---------:|---------:|------:|--------:|----------:|-------:|----------:|
|  ActivatorUtilities.CreateFactory |  61.94 ns | 0.308 ns | 0.289 ns |  0.37 |    0.00 |     294 B | 0.0105 |      88 B |
|                      NaiveFactory | 167.00 ns | 1.461 ns | 1.366 ns |  1.00 |    0.00 |     342 B | 0.0467 |     392 B |
| ActivatorUtilities.CreateInstance | 331.62 ns | 1.950 ns | 1.629 ns |  1.99 |    0.02 |     304 B | 0.0238 |     200 B |

## Sources

- https://github.com/davidfowl/DotNetCodingPatterns
