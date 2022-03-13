# Serialize/Deserialize JSON

**Task:**

- Deserialize the `FakeNames.json` file which contains 100K recors.
- Serialize the `List<FakeName>` list to string which contains 100K elements.

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.100-preview.1.22110.4
  [Host]     : .NET 7.0.0 (7.0.22.7608), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 7.0.0 (7.0.22.7608), X64 RyuJIT


```
|                               Method |     Mean |    Error |   StdDev |   Median | Code Size |     Gen 0 |    Gen 1 | Allocated |
|------------------------------------- |---------:|---------:|---------:|---------:|----------:|----------:|---------:|----------:|
|       SystemTextJsonDeserializeAsync | 266.8 ms | 11.69 ms | 34.48 ms | 278.5 ms |      0 MB | 1666.6667 | 666.6667 |     24 MB |
| SystemTextJsonSrcGenDeserializeAsync | 278.2 ms | 15.96 ms | 47.07 ms | 272.9 ms |      0 MB | 1666.6667 | 666.6667 |     24 MB |
|                                      |          |          |          |          |           |           |          |           |
|        SystemTextJsonSrcGenSerialize | 103.3 ms |  4.71 ms | 13.88 ms | 100.0 ms |      0 MB |  333.3333 |        - |     45 MB |
|              SystemTextJsonSerialize | 107.1 ms |  3.47 ms | 10.25 ms | 107.8 ms |      0 MB |  333.3333 |        - |     45 MB |

## Sources

**Data**

- https://www.fakenamegenerator.com/

**Ideas and inspirations**

- https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/
- https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-source-generation?pivots=dotnet-6-0
