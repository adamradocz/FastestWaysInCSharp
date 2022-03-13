namespace FastestWaysInCSharp.FileProcessing.Utilities;

public static class Data
{
    public const string CsvHeader = "Id,Guid,IsVip,Gender,GivenName,Surname,Birthday,Height,Weight,CreditCardNumber";
    public static string GetCsvTestFilePath() => Path.Combine("FileProcessing", "ParseCsv", "Data", "FakeNames.csv");
    public static string GetJsonTestFilePath() => Path.Combine("FileProcessing", "SerializeJson", "Data", "FakeNames.json");
}
