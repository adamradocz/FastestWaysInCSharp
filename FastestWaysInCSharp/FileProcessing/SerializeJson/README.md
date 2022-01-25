# Serialize/Deserialize JSON

**Task:**

- Deserialize the `FakeNames.json` file which contains 100K recors.
- Serialize the `List<FakeName>` list to string which contains 100K elements.

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1469 (21H2)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                               Method |     Mean |   Error |  StdDev | Code Size |     Gen 0 |     Gen 1 |     Gen 2 | Allocated |
|------------------------------------- |---------:|--------:|--------:|----------:|----------:|----------:|----------:|----------:|
|       SystemTextJsonDeserializeAsync | 312.7 ms | 1.52 ms | 1.42 ms |      0 MB | 6500.0000 | 3500.0000 |  500.0000 |     51 MB |
| SystemTextJsonSrcGenDeserializeAsync | 324.5 ms | 4.24 ms | 3.96 ms |      0 MB | 7000.0000 | 4000.0000 | 1000.0000 |     51 MB |
|                                      |          |         |         |           |           |           |           |           |
|        SystemTextJsonSrcGenSerialize | 118.7 ms | 0.35 ms | 0.33 ms |      0 MB |  400.0000 |         - |         - |     67 MB |
|              SystemTextJsonSerialize | 120.0 ms | 0.32 ms | 0.30 ms |      0 MB |  400.0000 |         - |         - |     67 MB |


## Sources

**Data**

- https://www.fakenamegenerator.com/

**Ideas and inspirations**

- https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/
- https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-source-generation?pivots=dotnet-6-0
