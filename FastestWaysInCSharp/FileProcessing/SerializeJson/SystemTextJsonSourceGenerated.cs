using FastestWaysInCSharp.FileProcessing.Model;
using System.Text.Json;

namespace FastestWaysInCSharp.FileProcessing.ParseJson;

public static class SystemTextJsonSourceGenerated
{
    public static async Task<List<FakeName>> DeserializeAsync(string filePath)
    {
        await using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 32768);
        return await JsonSerializer.DeserializeAsync<List<FakeName>>(fileStream, FakeNameJsonContext.Default.Options);
    }

    public static async IAsyncEnumerable<FakeName> DeserializeAsyncEnumerable(string filePath)
    {
        await using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 32768);
        await foreach (var fakeName in JsonSerializer.DeserializeAsyncEnumerable<FakeName>(fileStream, FakeNameJsonContext.Default.Options))
        {
            if (fakeName != null)
            {
                yield return fakeName;
            }
        }
    }

    public static string Serialize(in List<FakeName> fakeNames) => JsonSerializer.Serialize(fakeNames, FakeNameJsonContext.Default.Options);
}
