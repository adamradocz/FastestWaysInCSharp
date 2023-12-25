using FastestWaysInCSharp.FileProcessing.Model;
using System.Text.Json.Serialization;

namespace FastestWaysInCSharp.FileProcessing.ParseJson;

[JsonSerializable(typeof(List<FakeName>))]
[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default)]
public partial class FakeNameJsonContext : JsonSerializerContext
{
}
