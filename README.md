# Fatest ways in C#
The fastest way to do things in C#.

## String manipulation

### Multi substring

Task:
Given the following text: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."

Return the concatenated strings of the following substings:
- Start index: 0, Length: 5
- Start index: 28, Length: 11
- Start index: 116, Length: 6

The expected result is: "Loremconsecteturaliqua"

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1469 (21H2)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.200-preview.22055.15
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                      Method |     Mean |    Error |   StdDev | Code Size |  Gen 0 | Allocated |
|---------------------------- |---------:|---------:|---------:|----------:|-------:|----------:|
|         StringCreateClosure | 10.42 ns | 0.139 ns | 0.130 ns |     146 B | 0.0086 |      72 B |
|         StringCreateReverse | 11.18 ns | 0.153 ns | 0.127 ns |     146 B | 0.0086 |      72 B |
|                StringCreate | 12.11 ns | 0.267 ns | 0.250 ns |     146 B | 0.0086 |      72 B |
|         CharArrayStackAlloc | 12.91 ns | 0.226 ns | 0.200 ns |     246 B | 0.0086 |      72 B |
|                   CharArray | 15.59 ns | 0.161 ns | 0.126 ns |     177 B | 0.0172 |     144 B |
| CharArrayStackAllocToString | 16.05 ns | 0.143 ns | 0.119 ns |     537 B | 0.0086 |      72 B |
|                   Substring | 43.23 ns | 0.905 ns | 1.487 ns |     112 B | 0.0296 |     248 B |

### Character replace

Task:
Given the following text: "Lorem ipsum dolor sit amet."

Replace the 2nd character with a '#'.

The expected result is: "L#rem ipsum dolor sit amet"

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1469 (21H2)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.200-preview.22055.15
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|       Method |      Mean |     Error |    StdDev | Code Size |  Gen 0 | Allocated |
|------------- |----------:|----------:|----------:|----------:|-------:|----------:|
|       Unsafe |  1.109 ns | 0.0061 ns | 0.0048 ns |      48 B |      - |         - |
| StringCreate | 11.285 ns | 0.0897 ns | 0.0839 ns |     146 B | 0.0096 |      80 B |
|    Substring | 33.400 ns | 0.2392 ns | 0.2237 ns |     287 B | 0.0249 |     208 B |

### Convert string to int

Task:
Given the following text: "1234567890"

Convert the text to int.

The expected result is: 1234567890

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1469 (21H2)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.200-preview.22055.15
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|               Method |      Mean |     Error |    StdDev |    Median | Code Size | Allocated |
|--------------------- |----------:|----------:|----------:|----------:|----------:|----------:|
| CustomIntParseUnsafe |  5.584 ns | 0.0045 ns | 0.0040 ns |  5.583 ns |     116 B |         - |
|       CustomIntParse |  6.454 ns | 0.0348 ns | 0.0326 ns |  6.460 ns |     101 B |         - |
|       ConvertToInt32 | 14.550 ns | 0.0255 ns | 0.0239 ns | 14.543 ns |   1,342 B |         - |
|             IntParse | 15.714 ns | 0.3391 ns | 0.5476 ns | 15.356 ns |   1,342 B |         - |
