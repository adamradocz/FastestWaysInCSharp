using FastestWaysInCSharp.FileProcessing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FastestWaysInCSharp.FileProcessing.ParseJson;

[JsonSerializable(typeof(FakeName))]
[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default)]
public partial class FakeNameJsonContext : JsonSerializerContext
{
}
