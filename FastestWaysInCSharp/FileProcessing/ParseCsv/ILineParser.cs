namespace FastestWaysInCSharp.FileProcessing.ParseCsv;

public interface ILineParser
{
    public FakeName ParseLine(string line);
}
