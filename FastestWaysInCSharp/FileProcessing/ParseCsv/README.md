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
|                          Method |     Mean |   Error |  StdDev |      Gen 0 | Code Size |     Gen 1 |     Gen 2 | Allocated |
|-------------------------------- |---------:|--------:|--------:|-----------:|----------:|----------:|----------:|----------:|
| PipelinesAndSequenceReaderAsnyc | 124.1 ms | 2.42 ms | 2.27 ms |  4800.0000 |      0 MB | 2600.0000 |  800.0000 |     52 MB |
|              SylvanDataCsvAsync | 134.0 ms | 2.59 ms | 3.79 ms |  4500.0000 |      0 MB | 2750.0000 | 1000.0000 |     48 MB |
|                       SpanAsnyc | 188.7 ms | 2.01 ms | 1.88 ms |  9666.6667 |      0 MB | 4000.0000 | 1333.3333 |    106 MB |
|                StringArrayAsync | 220.9 ms | 3.39 ms | 3.17 ms | 12000.0000 |      0 MB | 4500.0000 | 1500.0000 |    139 MB |
|                  CsvHelperAsync | 320.7 ms | 6.33 ms | 8.88 ms | 13000.0000 |      0 MB | 4000.0000 | 1000.0000 |    167 MB |


## Sources

**Data**

- https://www.fakenamegenerator.com/

**Ideas and inspirations**

- https://github.com/indy-singh/StringsAreEvil
- https://goldytech.wordpress.com/2021/05/31/performance-booster-with-system-io-pipelines-in-c/
- https://www.joelverhagen.com/blog/2020/12/fastest-net-csv-parsers
