using FastestWaysInCSharp.FileProcessing.Model;
using Sylvan.Data.Csv;

namespace FastestWaysInCSharp.FileProcessing.ParseCsv;

public static class SylvanDataCsv
{
    public static async IAsyncEnumerable<FakeName> ParseAsync(string filePath)
    {
        var options = new CsvDataReaderOptions
        {
            BufferSize = 0x100000,
            Delimiter = ',',
            HasHeaders = true
        };

        await using var csv = CsvDataReader.Create(filePath, options);

        while (await csv.ReadAsync().ConfigureAwait(false))
        {
            yield return new FakeName
            {
                Id = csv.GetInt32(0),
                Guid = csv.GetGuid(1),
                IsVip = csv.GetBoolean(2),
                Gender = csv.GetChar(3),
                GivenName = csv.GetString(4),
                Surname = csv.GetString(5),
                Birthday = csv.GetDate(6),
                Height = csv.GetInt32(7),
                Weight = csv.GetFloat(8),
                CreditCardNumber = csv.GetInt64(9)
            };
        }
    }
}
