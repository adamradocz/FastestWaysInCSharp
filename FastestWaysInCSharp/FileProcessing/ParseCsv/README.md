# Parse CSV

**Task:**

Parse the `FakeNames.csv` file which contains 100K recors. The line ending is Unix styled "\n".

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1469 (21H2)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.200-preview.22055.15
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                          Method |     Mean |   Error |  StdDev |      Gen 0 | Code Size |     Gen 1 |     Gen 2 | Allocated |
|-------------------------------- |---------:|--------:|--------:|-----------:|----------:|----------:|----------:|----------:|
|                   SylvanDataCsv | 146.7 ms | 1.84 ms | 1.72 ms |  6500.0000 |      0 MB | 3750.0000 | 1250.0000 |     46 MB |
|                            Span | 173.9 ms | 3.37 ms | 4.94 ms | 13000.0000 |      0 MB | 5000.0000 | 1666.6667 |     99 MB |
|                     StringArray | 194.5 ms | 3.54 ms | 3.32 ms | 16666.6667 |      0 MB | 5333.3333 | 1333.3333 |    130 MB |
|                       CsvHelper | 307.0 ms | 3.44 ms | 3.22 ms | 21000.0000 |      0 MB | 7000.0000 | 2000.0000 |    164 MB |
|                                 |          |         |         |            |           |           |           |           |
|              SylvanDataCsvAsync | 170.2 ms | 3.14 ms | 3.62 ms |  6666.6667 |      0 MB | 3666.6667 | 1000.0000 |     47 MB |
|   PipelinesAndBufferReaderAsync | 176.9 ms | 2.18 ms | 2.04 ms |  7333.3333 |      0 MB | 4000.0000 | 1333.3333 |     53 MB |
| PipelinesAndSequenceReaderAsnyc | 177.3 ms | 2.29 ms | 2.15 ms |  7333.3333 |      0 MB | 4000.0000 | 1333.3333 |     54 MB |
|                       SpanAsnyc | 199.0 ms | 3.84 ms | 3.21 ms | 13666.6667 |      0 MB | 5000.0000 | 1666.6667 |    107 MB |
|                StringArrayAsync | 243.9 ms | 3.70 ms | 3.46 ms | 18000.0000 |      0 MB | 6000.0000 | 1666.6667 |    138 MB |
|                  CsvHelperAsync | 369.5 ms | 7.23 ms | 8.04 ms | 21000.0000 |      0 MB | 7000.0000 | 2000.0000 |    166 MB |

## Sources

**Data**

- https://www.fakenamegenerator.com/

**Ideas and inspirations**

- https://github.com/indy-singh/StringsAreEvil
- https://goldytech.wordpress.com/2021/05/31/performance-booster-with-system-io-pipelines-in-c/
- https://www.joelverhagen.com/blog/2020/12/fastest-net-csv-parsers
