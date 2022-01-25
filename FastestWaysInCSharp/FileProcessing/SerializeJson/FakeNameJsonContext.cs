using FastestWaysInCSharp.FileProcessing.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FastestWaysInCSharp.FileProcessing.ParseJson;

[JsonSerializable(typeof(FakeName))]
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, GenerationMode = JsonSourceGenerationMode.Default)]
public partial class FakeNameJsonContext : JsonSerializerContext
{
    private static JsonSerializerOptions Options = new();
    private static FakeNameJsonContext Context;

    static FakeNameJsonContext()
    {
        Options.Converters.Add(new DateOnlyConverterNullable());
        Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

        Context = new(Options);
    }
}
