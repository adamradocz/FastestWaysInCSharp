using FastestWaysInCSharp.FileProcessing.ParseCsv.Helpers;
using FastestWaysInCSharp.FileProcessing.ParseCsv.Model;
using System.Buffers;
using System.Buffers.Text;
using System.Text;

namespace FastestWaysInCSharp.FileProcessing.ParseCsv;

public static class FilePipeReaderAndSequenceReader
{
    private const byte _delimiterAsByte = (byte)';';
    private const byte _forwardSlashAsByte = (byte)'/';

    private static readonly byte[] _newLineAsByte = Encoding.UTF8.GetBytes(Environment.NewLine);
    private static readonly byte[] _header = Encoding.UTF8.GetBytes("Id;Guid;Gender;GivenName;Surname;City;StreetAddress;EmailAddress;Birthday;Height;Weight;CreditCardNumber;Domain");

    public static async Task<List<FakeName>> ParseAsync(string filePath)
    {
        var fakeNames = new List<FakeName>();
        var reader = new FilePipeReader(filePath);

        while (true)
        {
            var result = await reader.ReadAsync();
            var buffer = result.Buffer;

            var actualPosition = ParseLine(buffer, fakeNames);

            reader.AdvanceTo(actualPosition, buffer.End);

            if (result.IsCompleted)
            {
                break;
            }
        }

        reader.Complete();

        return fakeNames;
    }

    private static SequencePosition ParseLine(in ReadOnlySequence<byte> buffer, in List<FakeName> fakeNames)
    {
        var reader = new SequenceReader<byte>(buffer);
        while (reader.TryReadTo(out ReadOnlySpan<byte> line, _newLineAsByte))
        {
            var fakeName = GetFakeName(line);
            if (fakeName != null)
            {
                fakeNames.Add(fakeName);
            }
        }

        // Update the buffer
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

        try
        {

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

        }
        catch (Exception e )
        {

            throw;
        }

        // Height
        delimiterAt = line.IndexOf(_delimiterAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, delimiterAt), out int height, out _);
        fakeName.Height = height;
        line = line.Slice(delimiterAt + 1);

        // Weight
        delimiterAt = line.IndexOf(_delimiterAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, delimiterAt), out float weight, out _);
        fakeName.Weight = weight;
        line = line.Slice(delimiterAt + 1);

        // CreditCardNumber
        delimiterAt = line.IndexOf(_delimiterAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, delimiterAt), out long creditCardNumber, out _);
        fakeName.CreditCardNumber = creditCardNumber;
        line = line.Slice(delimiterAt + 1);

        // Domain
        fakeName.Domain = new string(Encoding.UTF8.GetString(line));

        return fakeName;
    }
}
