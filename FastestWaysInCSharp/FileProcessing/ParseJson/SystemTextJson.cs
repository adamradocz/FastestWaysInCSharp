using FastestWaysInCSharp.FileProcessing.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FastestWaysInCSharp.FileProcessing.ParseJson;

public static class SystemTextJson
{
    private static readonly JsonSerializerOptions _options = new(JsonSerializerDefaults.Web);

    static SystemTextJson()
    {
        _options.Converters.Add(new DateOnlyConverter());
        _options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    }

    public static async IAsyncEnumerable<FakeName> DeserializeAsync(string filePath)
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

    public static string Serialize(List<FakeName> fakeNames) => JsonSerializer.Serialize(fakeNames, _options);
}

public class DateOnlyConverter : JsonConverter<DateOnly>
{
    private readonly string _serializationFormat;

    public DateOnlyConverter() : this(null)
    {
    }

    public DateOnlyConverter(string? serializationFormat)
    {
        _serializationFormat = serializationFormat ?? "yyyy-MM-dd";
    }

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();
        return DateOnly.Parse(value);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString(_serializationFormat));
}