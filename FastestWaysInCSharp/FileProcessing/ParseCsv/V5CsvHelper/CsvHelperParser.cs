using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace FastestWaysInCSharp.FileProcessing.ParseCsv.V5CsvHelper;

public static class CsvHelperParser
{
    public static IEnumerable<FakeName> Parse(string filePath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = ",",
            NewLine = Environment.NewLine
        };

        using var streamReader = new StreamReader(filePath);
        using var csvReader = new CsvReader(streamReader, config);
        foreach (var fakeName in csvReader.GetRecords<FakeName>())
        {
            yield return fakeName;
        }
    }
}
