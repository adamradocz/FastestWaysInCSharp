# Parse CSV

**Task:**

Parse the `FakeNames.csv` file which contains 100K recors. The line ending is Windows styled "\r\n".

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1526 (21H2)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.102
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT


```
|                           Method |     Mean |   Error |  StdDev |      Gen 0 | Code Size |     Gen 1 |     Gen 2 | Allocated |
|--------------------------------- |---------:|--------:|--------:|-----------:|----------:|----------:|----------:|----------:|
|               SylvanDataCsvAsync | 141.6 ms | 1.99 ms | 1.86 ms |  6500.0000 |      0 MB | 3750.0000 | 1250.0000 |     48 MB |
|   FullPipeAndSequenceReaderAsnyc | 146.6 ms | 2.86 ms | 2.67 ms |  7250.0000 |      0 MB | 4000.0000 | 1250.0000 |     52 MB |
| PipeReaderAndSequenceReaderAsnyc | 150.7 ms | 2.89 ms | 3.33 ms |  7250.0000 |      0 MB | 4000.0000 | 1250.0000 |     52 MB |
|                        SpanAsnyc | 178.5 ms | 3.30 ms | 3.09 ms | 13666.6667 |      0 MB | 5000.0000 | 1666.6667 |    106 MB |
|                 StringArrayAsync | 234.5 ms | 4.60 ms | 9.19 ms | 18000.0000 |      0 MB | 6000.0000 | 2000.0000 |    139 MB |
|                   CsvHelperAsync | 356.2 ms | 5.61 ms | 5.24 ms | 21000.0000 |      0 MB | 7000.0000 | 2000.0000 |    167 MB |

## Sources

**Data**

- https://www.fakenamegenerator.com/

**Ideas and inspirations**

- https://github.com/indy-singh/StringsAreEvil
- https://goldytech.wordpress.com/2021/05/31/performance-booster-with-system-io-pipelines-in-c/
- https://www.joelverhagen.com/blog/2020/12/fastest-net-csv-parsers
