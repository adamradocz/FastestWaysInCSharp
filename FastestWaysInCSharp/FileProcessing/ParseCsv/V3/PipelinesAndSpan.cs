using System.Buffers;
using System.Buffers.Text;
using System.IO.Pipelines;
using System.Text;

namespace FastestWaysInCSharp.FileProcessing.ParseCsv.V3;

public static class PipelinesAndSpan
{
    private const byte _delimiterAsByte = (byte)';';
    private const byte _newLineAsByte = (byte)'\n';
    private const byte _forwardSlashAsByte = (byte)'/';

    private static readonly byte[] _header = Encoding.UTF8.GetBytes("Id;Guid;Gender;GivenName;Surname;City;StreetAddress;EmailAddress;Birthday;Domain");
    
    public static async IAsyncEnumerable<FakeName> ParseAsync(string filePath)
    {
        await using var fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
        var reader = PipeReader.Create(fileStream);
        while (true)
        {
            var data = await reader.ReadAsync();
            var dataBuffer = data.Buffer;

            // Parse
            var actualPosition = ParseLine(dataBuffer, out var fakeName);
            if (fakeName != null)
            {
                yield return fakeName;
            }

            reader.AdvanceTo(actualPosition, dataBuffer.End);

            if (data.IsCompleted)
            {
                break;
            }
        }

        await reader.CompleteAsync();
    }

    private static SequencePosition ParseLine(in ReadOnlySequence<byte> dataBuffer, out FakeName? fakeName)
    {
        fakeName = default;
        var reader = new SequenceReader<byte>(dataBuffer);
        while (reader.TryReadTo(out ReadOnlySpan<byte> line, _newLineAsByte))
        {
            fakeName = GetFakeName(line);
        }

        return reader.Position;
    }

    private static FakeName? GetFakeName(ReadOnlySpan<byte> line)
    {
        // Skip the header
        if (line.IndexOf(_header) >= 0)
        {
            return default;
        }

        var fakeName = new FakeName();

        // Id
        int delimiterAt = line.IndexOf(_delimiterAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, delimiterAt), out int id, out _);
        fakeName.Id = id;
        line = line.Slice(delimiterAt + 1);

        // Guid
        delimiterAt = line.IndexOf(_delimiterAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, delimiterAt), out Guid guid, out _);
        fakeName.Guid = guid;
        line = line.Slice(delimiterAt + 1);

        // Gender
        delimiterAt = line.IndexOf(_delimiterAsByte);
        fakeName.Gender = Encoding.UTF8.GetString(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // GivenName
        delimiterAt = line.IndexOf(_delimiterAsByte);
        fakeName.GivenName = Encoding.UTF8.GetString(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Surname
        delimiterAt = line.IndexOf(_delimiterAsByte);
        fakeName.Surname = Encoding.UTF8.GetString(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // City
        delimiterAt = line.IndexOf(_delimiterAsByte);
        fakeName.City = Encoding.UTF8.GetString(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // StreetAddress
        delimiterAt = line.IndexOf(_delimiterAsByte);
        fakeName.StreetAddress = Encoding.UTF8.GetString(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // EmailAddress
        delimiterAt = line.IndexOf(_delimiterAsByte);
        fakeName.EmailAddress = Encoding.UTF8.GetString(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Birthday
        // Month
        int slashAt = line.IndexOf(_forwardSlashAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, slashAt), out int month, out _);
        line = line.Slice(slashAt + 1);

        // Day
        slashAt = line.IndexOf(_forwardSlashAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, slashAt), out int day, out _);
        line = line.Slice(slashAt + 1);

        // Year
        delimiterAt = line.IndexOf(_delimiterAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, delimiterAt), out int year, out _);
        fakeName.Birthday = new DateOnly(year, month, day);
        line = line.Slice(delimiterAt + 1);

        // Domain
        fakeName.Domain = new string(Encoding.UTF8.GetString(line));

        return fakeName;
    }
}
