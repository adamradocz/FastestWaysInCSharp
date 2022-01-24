# Parse CSV

**Task:**

Parse the `FakeNames.csv` file which contains 100K recors. The line ending is Windows styled "\r\n".

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1469 (21H2)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.200-preview.22055.15
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                          Method |     Mean |   Error |  StdDev |      Gen 0 | Code Size |     Gen 1 |     Gen 2 | Allocated |
|-------------------------------- |---------:|--------:|--------:|-----------:|----------:|----------:|----------:|----------:|
|                   SylvanDataCsv | 144.6 ms | 2.04 ms | 1.81 ms |  6500.0000 |      0 MB | 3750.0000 | 1250.0000 |     46 MB |
|                            Span | 172.3 ms | 3.42 ms | 5.90 ms | 13000.0000 |      0 MB | 5000.0000 | 1666.6667 |     99 MB |
|                     StringArray | 192.8 ms | 3.73 ms | 4.58 ms | 16666.6667 |      0 MB | 5333.3333 | 1333.3333 |    130 MB |
|                       CsvHelper | 300.4 ms | 5.90 ms | 6.79 ms | 21000.0000 |      0 MB | 7000.0000 | 2000.0000 |    164 MB |
|                                 |          |         |         |            |           |           |           |           |
| PipelinesAndSequenceReaderAsnyc | 148.9 ms | 2.92 ms | 2.73 ms |  7250.0000 |      0 MB | 4000.0000 | 1250.0000 |     53 MB |
|              SylvanDataCsvAsync | 166.8 ms | 2.57 ms | 2.28 ms |  6333.3333 |      0 MB | 3666.6667 | 1000.0000 |     47 MB |
|                       SpanAsnyc | 197.0 ms | 3.93 ms | 5.11 ms | 13666.6667 |      0 MB | 5000.0000 | 1666.6667 |    107 MB |
|                StringArrayAsync | 231.3 ms | 2.54 ms | 2.12 ms | 18000.0000 |      0 MB | 6000.0000 | 2000.0000 |    138 MB |
|                  CsvHelperAsync | 366.6 ms | 7.08 ms | 6.62 ms | 21000.0000 |      0 MB | 7000.0000 | 2000.0000 |    166 MB |

## Sources

**Data**

- https://www.fakenamegenerator.com/

**Ideas and inspirations**

- https://github.com/indy-singh/StringsAreEvil
- https://goldytech.wordpress.com/2021/05/31/performance-booster-with-system-io-pipelines-in-c/
- https://www.joelverhagen.com/blog/2020/12/fastest-net-csv-parsers
