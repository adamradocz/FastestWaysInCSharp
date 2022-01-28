# Parse CSV

**Task:**

Parse the `FakeNames.csv` file which contains 100K recors. The line ending is Windows styled "\r\n".

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                          Method |     Mean |   Error |   StdDev |      Gen 0 | Code Size |     Gen 1 |     Gen 2 | Allocated |
|-------------------------------- |---------:|--------:|---------:|-----------:|----------:|----------:|----------:|----------:|
| PipelinesAndSequenceReaderAsnyc | 126.9 ms | 1.74 ms |  1.63 ms |  4800.0000 |      0 MB | 2600.0000 |  800.0000 |     53 MB |
|              SylvanDataCsvAsync | 186.4 ms | 6.28 ms | 18.52 ms |  4500.0000 |      0 MB | 2750.0000 | 1000.0000 |     47 MB |
|                       SpanAsnyc | 198.3 ms | 3.88 ms |  4.61 ms |  9666.6667 |      0 MB | 4000.0000 | 1333.3333 |    107 MB |
|                StringArrayAsync | 223.8 ms | 4.45 ms |  5.13 ms | 12333.3333 |      0 MB | 4666.6667 | 1666.6667 |    138 MB |
|                  CsvHelperAsync | 326.9 ms | 6.25 ms |  7.90 ms | 13000.0000 |      0 MB | 4000.0000 | 1000.0000 |    166 MB |

## Sources

**Data**

- https://www.fakenamegenerator.com/

**Ideas and inspirations**

- https://github.com/indy-singh/StringsAreEvil
- https://goldytech.wordpress.com/2021/05/31/performance-booster-with-system-io-pipelines-in-c/
- https://www.joelverhagen.com/blog/2020/12/fastest-net-csv-parsers
