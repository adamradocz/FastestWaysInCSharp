using FastestWaysInCSharp.FileProcessing.Model;
using System.Text.Json;

namespace FastestWaysInCSharp.FileProcessing.ParseJson;

public static class SystemTextJson
{
    private static readonly JsonSerializerOptions _options = new();

    static SystemTextJson()
    {
        _options.Converters.Add(new DateOnlyConverterNullable());
        _options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    }

    public static async Task<List<FakeName>> DeserializeAsync(string filePath)
    {
        await using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 32768);
        return await JsonSerializer.DeserializeAsync<List<FakeName>>(fileStream, _options);
    }

    public static async IAsyncEnumerable<FakeName> DeserializeAsyncEnumerable(string filePath)
    {
        await using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 32768);
        await foreach (var fakeName in JsonSerializer.DeserializeAsyncEnumerable<FakeName>(fileStream, _options))
        {
            if (fakeName != null)
            {
                yield return fakeName;
            }
        }
    }

    public static string Serialize(in List<FakeName> fakeNames) => JsonSerializer.Serialize(fakeNames, _options);
}