using System.Text.Json;
using System.Text.Json.Serialization;

namespace FastestWaysInCSharp.FileProcessing.ParseJson;

public class DateOnlyConverterNullable : JsonConverter<DateOnly?>
{
    private const string _dateFormat = "yyyy-MM-dd";
    private readonly string _serializationFormat;

    public DateOnlyConverterNullable() : this(null)
    {
    }

    public DateOnlyConverterNullable(string? serializationFormat)
    {
        _serializationFormat = serializationFormat ?? _dateFormat;
    }

    public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();
        return string.IsNullOrEmpty(value) ? null : DateOnly.Parse(value);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options) => writer.WriteStringValue(value == null ? string.Empty : value.Value.ToString(_serializationFormat));
}