using FastestWaysInCSharp.FileProcessing.Model;
using System.Globalization;
using System.Threading.Channels;

namespace FastestWaysInCSharp.FileProcessing.ParseCsv;

public static class SpanAndChannel
{
    private const char _delimiter = ',';

    public static async Task<List<FakeName>> ParseAsync(string filePath)
    {
        var fakeNames = new List<FakeName>(100000);

        using var streamReader = new StreamReader(filePath);
        var channelOptions = new UnboundedChannelOptions() { SingleReader = true, SingleWriter = true };
        var channel = Channel.CreateUnbounded<string>(channelOptions);

        // Skip the header
        _ = await streamReader.ReadLineAsync().ConfigureAwait(false);

        var consumer = ConsumeLineAsync(channel.Reader, fakeNames);
        var producer = ProduceLineAsync(channel.Writer, streamReader);        

        await Task.WhenAll(consumer, producer).ConfigureAwait(false);

        return fakeNames;
    }

    private static async Task ProduceLineAsync(ChannelWriter<string> channelWriter, StreamReader streamReader)
    {
        while (!streamReader.EndOfStream)
        {
            var line = await streamReader.ReadLineAsync().ConfigureAwait(false);
            if (!string.IsNullOrEmpty(line))
            {
                await channelWriter.WriteAsync(line).ConfigureAwait(false);
            }
        }

        channelWriter.Complete();
    }

    private static async Task ConsumeLineAsync(ChannelReader<string> reader, List<FakeName> fakeNames)
    {
        while (await reader.WaitToReadAsync().ConfigureAwait(false))
        {
            var line = await reader.ReadAsync().ConfigureAwait(false);
            var fakeName = ParseLine(line);
            fakeNames.Add(fakeName);
        }
    }

    private static FakeName ParseLine(ReadOnlySpan<char> line)
    {
        var fakeName = new FakeName();

        // Id
        var delimiterAt = line.IndexOf(_delimiter);
        fakeName.Id = int.Parse(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Guid
        delimiterAt = line.IndexOf(_delimiter);
        string value = new(line.Slice(0, delimiterAt));
        fakeName.Guid = new Guid(value);
        line = line.Slice(delimiterAt + 1);

        // IsVip
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.IsVip = line.Slice(0, delimiterAt)[0] == '1';
        line = line.Slice(delimiterAt + 1);

        // Gender
        delimiterAt = line.IndexOf(_delimiter);
        var gender = line.Slice(0, delimiterAt);
        fakeName.Gender = gender[0];
        line = line.Slice(delimiterAt + 1);

        // GivenName
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.GivenName = new string(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Surname
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.Surname = new string(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Birthday
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.Birthday = DateOnly.Parse(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Height
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.Height = int.Parse(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Weight
        delimiterAt = line.IndexOf(_delimiter);
        fakeName.Weight = float.Parse(line.Slice(0, delimiterAt), NumberStyles.Float, CultureInfo.InvariantCulture);
        line = line.Slice(delimiterAt + 1);

        // CreditCardNumber
        fakeName.CreditCardNumber = long.Parse(line);

        return fakeName;
    }
}
