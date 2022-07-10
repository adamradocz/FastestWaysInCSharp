# Serialize/Deserialize JSON

**Task:**

- Deserialize the `FakeNames.json` file which contains 100K recors.
- Serialize the `List<FakeName>` list to string which contains 100K elements.

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET 7.0.0 (7.0.22.30112), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 7.0.0 (7.0.22.30112), X64 RyuJIT


```
|                               Method |      Mean |    Error |   StdDev |     Gen 0 | Code Size |    Gen 1 |    Gen 2 | Allocated |
|------------------------------------- |----------:|---------:|---------:|----------:|----------:|---------:|---------:|----------:|
|       SystemTextJsonDeserializeAsync | 165.64 ms | 2.941 ms | 2.751 ms | 1500.0000 |      0 MB | 500.0000 | 250.0000 |     17 MB |
| SystemTextJsonSrcGenDeserializeAsync | 170.34 ms | 3.295 ms | 2.921 ms | 1000.0000 |      0 MB |        - |        - |     17 MB |
|                                      |           |          |          |           |           |          |          |           |
|        SystemTextJsonSrcGenSerialize |  68.80 ms | 1.319 ms | 1.761 ms |  125.0000 |      0 MB |        - |        - |     43 MB |
|              SystemTextJsonSerialize |  72.17 ms | 1.112 ms | 0.986 ms |         - |      0 MB |        - |        - |     40 MB |

## Sources

**Data**

- https://www.fakenamegenerator.com/

**Ideas and inspirations**

- https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/
- https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-source-generation?pivots=dotnet-6-0
