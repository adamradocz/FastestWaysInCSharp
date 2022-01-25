namespace FastestWaysInCSharp.FileProcessing.Utilities;

public static class Data
{
    public static string GetCsvTestFilePath() => Path.Combine("FileProcessing", "ParseCsv", "Data", "FakeNames.csv");
    public static string GetJsonTestFilePath() => Path.Combine("FileProcessing", "SerializeJson", "Data", "FakeNames.json");
}
