# Parse CSV

**Task:**

Parse the `FakeNames.csv` file which contains 100K recors. The line ending is Windows styled "\r\n".

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.100-preview.1.22110.4
  [Host]     : .NET 7.0.0 (7.0.22.7608), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 7.0.0 (7.0.22.7608), X64 RyuJIT


```
|                           Method |      Mean |    Error |   StdDev |      Gen 0 | Code Size |     Gen 1 |     Gen 2 | Allocated |
|--------------------------------- |----------:|---------:|---------:|-----------:|----------:|----------:|----------:|----------:|
| PipeReaderAndSequenceReaderAsnyc |  48.74 ms | 0.699 ms | 0.654 ms |  1363.6364 |      0 MB |  818.1818 |  272.7273 |     16 MB |
|   FullPipeAndSequenceReaderAsnyc |  50.52 ms | 0.870 ms | 0.727 ms |  1500.0000 |      0 MB |  900.0000 |  300.0000 |     16 MB |
|               SylvanDataCsvAsync |  66.53 ms | 1.251 ms | 1.339 ms |  1500.0000 |      0 MB | 1125.0000 |  750.0000 |     19 MB |
|                        SpanAsnyc |  97.98 ms | 1.501 ms | 1.404 ms |  4833.3333 |      0 MB | 2166.6667 |  833.3333 |     57 MB |
|                 StringArrayAsync | 129.10 ms | 2.557 ms | 2.945 ms |  8000.0000 |      0 MB | 2750.0000 | 1250.0000 |     91 MB |
|                   CsvHelperAsync | 216.85 ms | 3.894 ms | 3.452 ms | 10000.0000 |      0 MB | 3000.0000 | 1000.0000 |    122 MB |

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
