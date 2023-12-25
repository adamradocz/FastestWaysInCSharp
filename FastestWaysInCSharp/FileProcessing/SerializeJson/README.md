# Serialize/Deserialize JSON

**Task:**

- Deserialize the `FakeNames.json` file which contains 100K recors.
- Serialize the `List<FakeName>` list to string which contains 100K elements.

```

BenchmarkDotNet v0.13.11, Windows 11 (10.0.22621.2861/22H2/2022Update/SunValley2)
11th Gen Intel Core i7-11370H 3.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method                               | Mean      | Error    | StdDev   | Code Size | Gen0      | Gen1      | Gen2     | Allocated |
|------------------------------------- |----------:|---------:|---------:|----------:|----------:|----------:|---------:|----------:|
| SystemTextJsonSrcGenDeserializeAsync | 130.32 ms | 1.073 ms | 0.951 ms |     409 B | 2000.0000 | 1000.0000 |        - |  16.78 MB |
| SystemTextJsonDeserializeAsync       | 131.92 ms | 1.223 ms | 1.144 ms |     409 B | 2000.0000 | 1000.0000 |        - |  16.78 MB |
|                                      |           |          |          |           |           |           |          |           |
| SystemTextJsonSrcGenSerialize        |  51.30 ms | 0.376 ms | 0.314 ms |     246 B |  600.0000 |  300.0000 | 300.0000 |  42.74 MB |
| SystemTextJsonSerialize              |  65.41 ms | 0.283 ms | 0.250 ms |   1,407 B |  250.0000 |  250.0000 | 250.0000 |  40.45 MB |


## Sources

**Data**

- https://www.fakenamegenerator.com/

**Ideas and inspirations**

- https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/
- https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-source-generation?pivots=dotnet-6-0
