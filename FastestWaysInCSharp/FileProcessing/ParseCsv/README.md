# Parse CSV

**Task:**

Parse the `FakeNames.csv` file which contains 100K recors. The line ending is Windows styled "\r\n".

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET 7.0.0 (7.0.22.30112), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 7.0.0 (7.0.22.30112), X64 RyuJIT


```
|                           Method |      Mean |    Error |   StdDev |      Gen 0 | Code Size |     Gen 1 |     Gen 2 | Allocated |
|--------------------------------- |----------:|---------:|---------:|-----------:|----------:|----------:|----------:|----------:|
|   FullPipeAndSequenceReaderAsnyc |  44.21 ms | 0.872 ms | 1.163 ms |  1416.6667 |      0 MB |  416.6667 |  250.0000 |     16 MB |
| PipeReaderAndSequenceReaderAsnyc |  45.84 ms | 0.637 ms | 0.532 ms |  1363.6364 |      0 MB |  363.6364 |  181.8182 |     16 MB |
|               SylvanDataCsvAsync |  83.25 ms | 1.381 ms | 1.153 ms |  1571.4286 |      0 MB | 1142.8571 |  571.4286 |     19 MB |
|              SpanAndChannelAsnyc |  91.00 ms | 1.653 ms | 1.546 ms |  5500.0000 |      0 MB | 3166.6667 | 1166.6667 |     57 MB |
|                        SpanAsnyc | 118.00 ms | 2.202 ms | 2.621 ms |  5400.0000 |      0 MB | 3000.0000 | 1000.0000 |     57 MB |
|                 StringArrayAsync | 167.39 ms | 3.160 ms | 4.325 ms |  8666.6667 |      0 MB | 3333.3333 | 1666.6667 |     92 MB |
|                   CsvHelperAsync | 242.95 ms | 4.701 ms | 6.112 ms | 10000.0000 |      0 MB | 3000.0000 | 1000.0000 |    124 MB |

## What to choose?

- If you want the best performance: Write your custom parser and use `PipeReader` and `SequenceReader`
- If you want simplicity but still amazing performance: [Sylvan.Data.Csv](https://github.com/MarkPflug/Sylvan/blob/main/docs/Csv/Sylvan.Data.Csv.md)

## Sources

**Data**

- https://www.fakenamegenerator.com/

**Ideas and inspirations**

- https://github.com/indy-singh/StringsAreEvil
- https://goldytech.wordpress.com/2021/05/31/performance-booster-with-system-io-pipelines-in-c/
- https://www.joelverhagen.com/blog/2020/12/fastest-net-csv-parsers
- https://itnext.io/use-system-io-pipelines-and-system-threading-channels-apis-to-boost-performance-832d7ab7c719
