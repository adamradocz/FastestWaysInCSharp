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

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1469 (21H2)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                                     Method |     Mean |    Error |   StdDev | Ratio | Code Size |  Gen 0 | Allocated |
|------------------------------------------- |---------:|---------:|---------:|------:|----------:|-------:|----------:|
| &#39;String.Create - Reverse - SkipLocalsInit&#39; | 11.01 ns | 0.100 ns | 0.094 ns |  0.25 |     146 B | 0.0086 |      72 B |
|                  &#39;String.Create - Reverse&#39; | 13.31 ns | 0.079 ns | 0.070 ns |  0.30 |     146 B | 0.0086 |      72 B |
|                              String.Create | 13.37 ns | 0.147 ns | 0.137 ns |  0.30 |     146 B | 0.0086 |      72 B |
|                  &#39;String.Create - Closure&#39; | 16.38 ns | 0.160 ns | 0.142 ns |  0.37 |     146 B | 0.0086 |      72 B |
|                   &#39;CharArray - StackAlloc&#39; | 17.93 ns | 0.235 ns | 0.220 ns |  0.41 |     808 B | 0.0086 |      72 B |
|                                  CharArray | 21.00 ns | 0.113 ns | 0.094 ns |  0.48 |     735 B | 0.0172 |     144 B |
|        &#39;CharArray - StackAlloc - ToString&#39; | 23.41 ns | 0.365 ns | 0.342 ns |  0.53 |   1,109 B | 0.0086 |      72 B |
|                                    Zstring | 34.41 ns | 0.164 ns | 0.153 ns |  0.79 |     774 B | 0.0086 |      72 B |
|                                  Substring | 43.82 ns | 0.296 ns | 0.263 ns |  1.00 |     133 B | 0.0296 |     248 B |


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

## String Concatenation

**Task:**

Create the following string: "Hello world at {date}.{Environment.NewLine}I'm {firstName} {lastName} and my favorite number is {number}."

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1469 (21H2)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|            Method |     Mean |   Error |  StdDev | Code Size |  Gen 0 | Allocated |
|------------------ |---------:|--------:|--------:|----------:|-------:|----------:|
| StringBuilderPool | 201.8 ns | 0.72 ns | 0.67 ns |     472 B | 0.0286 |     240 B |
|     Interpolation | 202.9 ns | 0.52 ns | 0.48 ns |   1,108 B | 0.0200 |     168 B |
|           Zstring | 210.2 ns | 0.70 ns | 0.54 ns |   2,143 B | 0.0286 |     240 B |
|      PlusOperator | 227.8 ns | 0.85 ns | 0.79 ns |     323 B | 0.0429 |     360 B |
|     StringBuilder | 276.1 ns | 1.99 ns | 1.56 ns |     439 B | 0.0935 |     784 B |
|      StringConcat | 286.5 ns | 1.86 ns | 1.74 ns |     372 B | 0.0792 |     664 B |
|      StringFormat | 327.8 ns | 0.66 ns | 0.62 ns |     220 B | 0.0334 |     280 B |
