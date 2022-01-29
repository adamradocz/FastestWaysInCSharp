using FastestWaysInCSharp.FileProcessing.Model;
using System.Globalization;

namespace FastestWaysInCSharp.FileProcessing.ParseCsv;

public static class Span
{
    private const char _delimiter = ',';
    private static readonly FileStreamOptions _fileStreamOptions = new()
    { Mode = FileMode.Open, Access = FileAccess.Read, Share = FileShare.ReadWrite, BufferSize = 32768, Options = FileOptions.SequentialScan };

public static async IAsyncEnumerable<FakeName> ParseAsync(string filePath)
    {
        using var reader = new StreamReader(filePath, _fileStreamOptions);

        // Skip the header
        _ = await reader.ReadLineAsync();

        while (!reader.EndOfStream)
        {
            string? line = await reader.ReadLineAsync();
            if (!string.IsNullOrEmpty(line))
            {
                yield return ParseLine(line);
            }
        }
    }

    private static FakeName ParseLine(ReadOnlySpan<char> line)
    {
        var fakeName = new FakeName();

        // Id
        int delimiterAt = line.IndexOf(_delimiter);
        fakeName.Id = int.Parse(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Guid
        delimiterAt = line.IndexOf(_delimiter);
        string value = new(line.Slice(0, delimiterAt));
        fakeName.Guid = new Guid(value);
        line = line.Slice(delimiterAt + 1);

        // Gender
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.Gender = new string(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // GivenName
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.GivenName = new string(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Surname
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.Surname = new string(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // City
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.City = new string(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // StreetAddress
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.StreetAddress = new string(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // EmailAddress
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.EmailAddress = new string(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Birthday
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.Birthday = DateOnly.Parse(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Height
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.Height = int.Parse(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Weight
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.Weight = float.Parse(line.Slice(0, delimiterAt), NumberStyles.Float, CultureInfo.InvariantCulture);
        line = line.Slice(delimiterAt + 1);

        // CreditCardNumber
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.CreditCardNumber = long.Parse(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Domain
        fakeName.Domain = new string(line);

        return fakeName;
    }
}
