using CsvHelper;
using CsvHelper.Configuration;
using FastestWaysInCSharp.FileProcessing.Model;
using System.Globalization;

namespace FastestWaysInCSharp.FileProcessing.ParseCsv;

public static class CsvHelperParser
{
    private static readonly CsvConfiguration _csvConfiguration = new(CultureInfo.InvariantCulture)
    {
        HasHeaderRecord = true,
        Delimiter = ",",
        NewLine = "\r\n"
    };

    public static async IAsyncEnumerable<FakeName> ParseAsync(string filePath)
    {
        using var streamReader = new StreamReader(filePath);
        using var csvReader = new CsvReader(streamReader, _csvConfiguration);
        await foreach (var fakeName in csvReader.GetRecordsAsync<FakeName>())
        {
            yield return fakeName;
        }
    }
}
