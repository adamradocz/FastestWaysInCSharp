# String manipulation

## Multi substring

**Task:**

Given the following text: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."

Return the concatenated strings of the following substings:
- Start index: 0, Length: 5
- Start index: 28, Length: 11
- Start index: 116, Length: 6

The expected result is: "Loremconsecteturaliqua"

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                      Method |     Mean |    Error |   StdDev | Code Size |  Gen 0 | Allocated |
|---------------------------- |---------:|---------:|---------:|----------:|-------:|----------:|
|         StringCreateReverse | 10.66 ns | 0.139 ns | 0.123 ns |     146 B | 0.0057 |      72 B |
|                StringCreate | 12.05 ns | 0.222 ns | 0.207 ns |     146 B | 0.0057 |      72 B |
|         StringCreateClosure | 15.44 ns | 0.241 ns | 0.202 ns |     146 B | 0.0057 |      72 B |
|         CharArrayStackAlloc | 17.20 ns | 0.394 ns | 0.840 ns |     808 B | 0.0057 |      72 B |
|                   CharArray | 18.90 ns | 0.411 ns | 0.422 ns |     735 B | 0.0115 |     144 B |
| CharArrayStackAllocToString | 21.97 ns | 0.326 ns | 0.289 ns |   1,109 B | 0.0057 |      72 B |
|                   Substring | 41.08 ns | 0.630 ns | 0.558 ns |     133 B | 0.0197 |     248 B |


## Character replace

**Task:**

Given the following text: "Lorem ipsum dolor sit amet"

Replace the 2nd character with a '#'.

The expected result is: "L#rem ipsum dolor sit amet"

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|       Method |       Mean |     Error |    StdDev | Code Size |  Gen 0 | Allocated |
|------------- |-----------:|----------:|----------:|----------:|-------:|----------:|
|       Unsafe |  0.8502 ns | 0.0531 ns | 0.0497 ns |      76 B |      - |         - |
| StringCreate | 11.9207 ns | 0.1523 ns | 0.1425 ns |     146 B | 0.0064 |      80 B |
|    Substring | 34.3986 ns | 0.6134 ns | 0.5738 ns |     296 B | 0.0166 |     208 B |

## Convert string to int

**Task:**

Given a random positive integer in string format.
Convert the text to int.

Benchmark: "1234567890" -> 1234567890

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|               Method |      Mean |     Error |    StdDev | Code Size | Allocated |
|--------------------- |----------:|----------:|----------:|----------:|----------:|
| CustomIntParseUnsafe |  4.289 ns | 0.1019 ns | 0.0953 ns |     116 B |         - |
|       CustomIntParse |  5.504 ns | 0.0919 ns | 0.0815 ns |     101 B |         - |
|             IntParse | 13.418 ns | 0.2500 ns | 0.3505 ns |   1,358 B |         - |
|       ConvertToInt32 | 13.498 ns | 0.2869 ns | 0.3415 ns |   1,351 B |         - |

## Convert substring to int

**Task:**

Given the following text: "Lorem 69 ipsum dolor sit amet"

Convert the "69" substring to int. The intereg is always located on the same position and always 2 digit long.

The expected result is: 69

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1469 (21H2)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.200-preview.22055.15
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                 Method |       Mean |     Error |    StdDev | Code Size |  Gen 0 | Allocated |
|----------------------- |-----------:|----------:|----------:|----------:|-------:|----------:|
| SpecificCustomIntParse |  0.6278 ns | 0.0005 ns | 0.0004 ns |      67 B |      - |         - |
| SpanGenericCustomParse |  2.6415 ns | 0.0053 ns | 0.0044 ns |      91 B |      - |         - |
|           SpanIntParse |  8.5258 ns | 0.0033 ns | 0.0029 ns |     139 B |      - |         - |
|      SubstringIntParse | 15.2700 ns | 0.1730 ns | 0.1619 ns |     137 B | 0.0038 |      32 B |

## Parse byte array string to int

**Task:**

Given a random positive integer in string format, converted to byte array.
Parse the byte array to int.

Benchmark: System.Text.Encoding.UTF8.GetBytes("1234567890") -> 1234567890

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|             Method |      Mean |     Error |    StdDev | Code Size |  Gen 0 | Allocated |
|------------------- |----------:|----------:|----------:|----------:|-------:|----------:|
|     CustomIntParse |  5.455 ns | 0.1001 ns | 0.0836 ns |     116 B |      - |         - |
| Utf8ParserTryParse |  6.575 ns | 0.1494 ns | 0.1467 ns |     177 B |      - |         - |
|  GetStringIntParse | 30.108 ns | 0.5848 ns | 0.6257 ns |     461 B | 0.0038 |      48 B |
