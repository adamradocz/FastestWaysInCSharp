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
        _ = await reader.ReadLineAsync().ConfigureAwait(false);

        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync().ConfigureAwait(false);
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
        var delimiterAt = line.IndexOf(_delimiter);
        fakeName.Id = int.Parse(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Guid
        delimiterAt = line.IndexOf(_delimiter);
        string value = new(line.Slice(0, delimiterAt));
        fakeName.Guid = new Guid(value);
        line = line.Slice(delimiterAt + 1);

        // IsVip
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.IsVip = line.Slice(0, delimiterAt)[0] == '1';
        line = line.Slice(delimiterAt + 1);

        // Gender
        delimiterAt = line.IndexOf(_delimiter);
        var gender = line.Slice(0, delimiterAt);
        fakeName.Gender = gender[0];
        line = line.Slice(delimiterAt + 1);

        // GivenName
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.GivenName = new string(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Surname
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.Surname = new string(line.Slice(0, delimiterAt));
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
        fakeName.CreditCardNumber = long.Parse(line);

        return fakeName;
    }
}
