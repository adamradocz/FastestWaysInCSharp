namespace FastestWaysInCSharp.FileProcessing.ParseCsv.V1;

public class ReadLineSplit
{
    public void Parse(string csvFilePath)
    {
        using var reader = File.OpenText(csvFilePath);

        // Skip the header
        _ = reader.ReadLine();

        while (reader.EndOfStream == false)
        {
            string? line = reader.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                _ = ParseLine(line);
            }
        }

        reader.Close();
    }

    private FakeName ParseLine(in string line)
    {
        string[] parts = line.Split(';');
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
            Domain = parts[9]
        };
    }
}
