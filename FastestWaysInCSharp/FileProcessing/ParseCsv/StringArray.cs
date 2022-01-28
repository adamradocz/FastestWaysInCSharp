using FastestWaysInCSharp.FileProcessing.Model;
using System.Globalization;

namespace FastestWaysInCSharp.FileProcessing.ParseCsv;

public static class StringArray
{
    private const char _delimiter = ';';

    public static async IAsyncEnumerable<FakeName> ParseAsync(string filePath)
    {
        using var reader = new StreamReader(filePath);

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

    private static FakeName ParseLine(in string line)
    {
        string[] parts = line.Split(_delimiter);
        return new FakeName
        {
            Id = int.Parse(parts[0]),
            Guid = new Guid(parts[1]),
            Gender = parts[2],
            GivenName = parts[3],
            Surname = parts[4],
            City = parts[5],
            StreetAddress = parts[6],
            EmailAddress = parts[7],
            Birthday = DateOnly.Parse(parts[8]),
            Height = int.Parse(parts[9]),
            Weight = float.Parse(parts[10], NumberStyles.Float, CultureInfo.InvariantCulture),
            CreditCardNumber = long.Parse(parts[11]),
            Domain = parts[12]
        };
    }
}
