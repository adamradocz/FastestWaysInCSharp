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
|   FullPipeAndSequenceReaderAsnyc |  44.53 ms | 0.886 ms | 1.270 ms |  1363.6364 |      0 MB |  363.6364 |  181.8182 |     16 MB |
| PipeReaderAndSequenceReaderAsnyc |  47.28 ms | 0.932 ms | 1.275 ms |  1500.0000 |      0 MB |  500.0000 |  250.0000 |     16 MB |
|               SylvanDataCsvAsync |  80.45 ms | 1.542 ms | 1.950 ms |  1571.4286 |      0 MB | 1142.8571 |  571.4286 |     19 MB |
|          FullPipeAndChannelAsnyc |  97.55 ms | 1.947 ms | 3.559 ms |  5166.6667 |      0 MB | 5000.0000 | 1666.6667 |     47 MB |
|       StringArrayAndChannelAsnyc | 108.99 ms | 2.164 ms | 3.304 ms |  8000.0000 |      0 MB | 2600.0000 |  800.0000 |     91 MB |
|                        SpanAsnyc | 124.15 ms | 2.464 ms | 3.688 ms |  5400.0000 |      0 MB | 3000.0000 | 1000.0000 |     57 MB |
|                 StringArrayAsync | 171.53 ms | 3.422 ms | 6.511 ms |  8666.6667 |      0 MB | 3333.3333 | 1666.6667 |     92 MB |
|                   CsvHelperAsync | 250.88 ms | 4.799 ms | 7.750 ms | 10000.0000 |      0 MB | 3000.0000 | 1000.0000 |    124 MB |

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
