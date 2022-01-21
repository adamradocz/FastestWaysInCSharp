using System.Text;

namespace FastestWaysInCSharp.FileProcessing.ParseCsv.V1;

public static class ReadLineSlice
{
    public static List<FakeName> Parse(in string csvFilePath)
    {
        var fakeNames = new List<FakeName>();

        using var reader = File.OpenText(csvFilePath);

        // Skip the header
        _ = reader.ReadLine();

        while (reader.EndOfStream == false)
        {
            string? line = reader.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                fakeNames.Add(ParseLine(line));
            }
        }

        return fakeNames;
    }

    private static FakeName ParseLine(ReadOnlySpan<char> line)
    {
        var fakeName = new FakeName();
        int fieldCount = 1;

        while (true)
        {
            int indexOfSemiColon = line.IndexOf(';');
            
            switch (fieldCount)
            {
                case 1:
                {
                    fakeName.Id = int.Parse(line[..indexOfSemiColon]);
                    break;
                }
                case 2:
                {
                    string value = new(line[..indexOfSemiColon]);
                    fakeName.Guid = new Guid(value);
                    break;
                }
                case 3:
                {
                    fakeName.Gender = new string(line[..indexOfSemiColon]);
                    break;
                }
                case 4:
                {
                    fakeName.GivenName = new string(line[..indexOfSemiColon]);
                    break;
                }
                case 5:
                {
                    fakeName.Surname = new string(line[..indexOfSemiColon]);
                    break;
                }
                case 6:
                {
                    fakeName.City = new string(line[..indexOfSemiColon]);
                    break;
                }
                case 7:
                {
                    fakeName.StreetAddress = new string(line[..indexOfSemiColon]);
                    break;
                }
                case 8:
                {
                    fakeName.EmailAddress = new string(line[..indexOfSemiColon]);
                    break;
                }
                case 9:
                {
                    int indexOfSlash = line.IndexOf('/');
                    int month = int.Parse(line.Slice(0, indexOfSlash));
                    line = line.Slice(indexOfSlash + 1);

                    indexOfSlash = line.IndexOf('/');
                    int day = int.Parse(line.Slice(0, indexOfSlash));
                    line = line.Slice(indexOfSlash + 1);

                    indexOfSemiColon = line.IndexOf(';');
                    int year = int.Parse(line.Slice(0, indexOfSemiColon));
                    fakeName.Birthday = new DateOnly(year, month, day);
                    break;
                }
                case 10:
                {
                    fakeName.Domain = new string(line);
                    return fakeName;
                }
            }

            fieldCount++;
            line = line[(indexOfSemiColon + 1)..]; // Slice past field.
        }
    }
}
