namespace FastestWaysInCSharp.FileProcessing.ParseCsv.V1ReadAllText;

public class ReadAllText : ILineParser
{
    public void Parse(string csvFilePath)
    {
        using StreamReader reader = File.OpenText(csvFilePath);
        while (reader.EndOfStream == false)
        {
            lineParser.ParseLine(reader.ReadLine());
        }
    }

    public void ParseLine(string csvFilePath) => throw new NotImplementedException();
}
