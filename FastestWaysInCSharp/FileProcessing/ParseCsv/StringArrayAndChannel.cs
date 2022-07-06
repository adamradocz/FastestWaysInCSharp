using FastestWaysInCSharp.FileProcessing.Model;
using System.Globalization;
using System.Threading.Channels;

namespace FastestWaysInCSharp.FileProcessing.ParseCsv;

public static class StringArrayAndChannel
{
    private const char _delimiter = ',';

    public static async Task<List<FakeName>> ParseAsync(string filePath)
    {
        var fakeNames = new List<FakeName>(100000);

        using var streamReader = new StreamReader(filePath);
        var channelOptions = new UnboundedChannelOptions() { SingleReader = true, SingleWriter = true };
        var channel = System.Threading.Channels.Channel.CreateUnbounded<string>(channelOptions);

        // Skip the header
        _ = await streamReader.ReadLineAsync().ConfigureAwait(false);

        var consumer = ProcessLineAsync(channel.Reader, fakeNames);
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
                await channelWriter.WriteAsync(line);
            }
        }

        channelWriter.Complete();
    }

    private static async Task ProcessLineAsync(ChannelReader<string> reader, List<FakeName> fakeNames)
    {
        while (await reader.WaitToReadAsync())
        {
            fakeNames.Add(ParseLine(await reader.ReadAsync()));
        }
    }

    private static FakeName ParseLine(string line)
    {
        var parts = line.Split(_delimiter);
        return new FakeName
        {
            Id = int.Parse(parts[0], CultureInfo.InvariantCulture),
            Guid = new Guid(parts[1]),
            IsVip = parts[2][0] == '1',
            Gender = parts[3][0],
            GivenName = parts[4],
            Surname = parts[5],
            Birthday = DateOnly.Parse(parts[6], CultureInfo.InvariantCulture),
            Height = int.Parse(parts[7], CultureInfo.InvariantCulture),
            Weight = float.Parse(parts[8], NumberStyles.Float, CultureInfo.InvariantCulture),
            CreditCardNumber = long.Parse(parts[9], CultureInfo.InvariantCulture)
        };
    }
}
