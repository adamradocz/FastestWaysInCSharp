using FastestWaysInCSharp.FileProcessing.Model;
using Sylvan.Data.Csv;

namespace FastestWaysInCSharp.FileProcessing.ParseCsv;

public static class SylvanDataCsv
{
    public static IEnumerable<FakeName> Parse(string filePath)
    {
        using var csv = CsvDataReader.Create(filePath);

        while (csv.Read())
        {
            yield return new FakeName
            {
                Id = csv.GetInt32(0),
                Guid = csv.GetGuid(1),
                Gender = csv.GetString(2),
                GivenName = csv.GetString(3),
                Surname = csv.GetString(4),
                City = csv.GetString(5),
                StreetAddress = csv.GetString(6),
                EmailAddress = csv.GetString(7),
                Birthday = csv.GetDate(8),
                Height = csv.GetInt32(9),
                Weight = csv.GetFloat(10),
                CreditCardNumber = csv.GetInt64(11),
                Domain = csv.GetString(12)
            };
        }
    }

    public static async IAsyncEnumerable<FakeName> ParseAsync(string filePath)
    {
        await using var csv = CsvDataReader.Create(filePath);

        while (await csv.ReadAsync())
        {
            yield return new FakeName
            {
                Id = csv.GetInt32(0),
                Guid = csv.GetGuid(1),
                Gender = csv.GetString(2),
                GivenName = csv.GetString(3),
                Surname = csv.GetString(4),
                City = csv.GetString(5),
                StreetAddress = csv.GetString(6),
                EmailAddress = csv.GetString(7),
                Birthday = csv.GetDate(8),
                Height = csv.GetInt32(9),
                Weight = csv.GetFloat(10),
                CreditCardNumber = csv.GetInt64(11),
                Domain = csv.GetString(12)
            };
        }
    }
}
