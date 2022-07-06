using FastestWaysInCSharp.FileProcessing.Model;
using System.Buffers;
using System.Buffers.Text;
using System.Globalization;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Channels;

namespace FastestWaysInCSharp.FileProcessing.ParseCsv;

public static class FullPipeAndChannel
{
    private const char _delimiter = ',';

    private static readonly byte[] _newLineAsByte = Encoding.UTF8.GetBytes("\r\n");

    public static async Task<List<FakeName>> ParseAsync(string filePath)
    {
        var fakeNames = new List<FakeName>(100000);

        await using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 32768, FileOptions.SequentialScan);
        var pipe = new Pipe();
        var channelOptions = new UnboundedChannelOptions() { SingleReader = true, SingleWriter = true };
        var channel = System.Threading.Channels.Channel.CreateUnbounded<string>(channelOptions);

        var channelConsumer = ProcessLineAsync(channel.Reader, fakeNames);
        var pipeFiller = FillPipeAsync(pipe.Writer, fileStream);
        var pipeReader = ReadPipeAsync(pipe.Reader, channel.Writer);
        await Task.WhenAll(pipeFiller, pipeReader, channelConsumer).ConfigureAwait(false);
        
        return fakeNames;
    }

    private static async Task FillPipeAsync(PipeWriter writer, FileStream stream)
    {
        await stream.CopyToAsync(writer.AsStream()).ConfigureAwait(false);
        await writer.CompleteAsync().ConfigureAwait(false);
    }

    static async Task ReadPipeAsync(PipeReader reader, ChannelWriter<string> channelWriter)
    {
        while (true)
        {
            var readResult = await reader.ReadAsync().ConfigureAwait(false);

            // Convert to Buffer
            var buffer = readResult.Buffer;

            ProduceLine(ref buffer, channelWriter);

            reader.AdvanceTo(buffer.Start, buffer.End);

            if (readResult.IsCompleted)
            {
                break;
            }
        }

        await reader.CompleteAsync().ConfigureAwait(false);
        channelWriter.Complete();
    }

    private static void ProduceLine(ref ReadOnlySequence<byte> buffer, ChannelWriter<string> channelWriter)
    {
        // Checking that the buffer is only single segment and reading the lines without the SequenceReader seems quite a bit overkill,
        // but why not.
        if (buffer.IsSingleSegment)
        {
            var firstSpan = buffer.FirstSpan;
            while (firstSpan.Length > 0)
            {
                var indexOfNewLineByte = firstSpan.IndexOf(_newLineAsByte);
                if (indexOfNewLineByte == -1)
                {
                    return;
                }

                var line = firstSpan.Slice(0, indexOfNewLineByte);

                _ = channelWriter.TryWrite(Encoding.UTF8.GetString(line));

                var consumed = indexOfNewLineByte + _newLineAsByte.Length;
                firstSpan = firstSpan.Slice(consumed);
                buffer = buffer.Slice(consumed);
            }
        }
        else
        {
            var reader = new SequenceReader<byte>(buffer);
            while (reader.TryReadTo(out ReadOnlySpan<byte> line, _newLineAsByte))
            {
                _ = channelWriter.TryWrite(Encoding.UTF8.GetString(line));
            }

            buffer = buffer.Slice(reader.Position);
        }
    }

    private static async Task ProcessLineAsync(ChannelReader<string> reader, List<FakeName> fakeNames)
    {
        while (await reader.WaitToReadAsync())
        {
            var line = await reader.ReadAsync();
            if (line.Equals("Id,Guid,IsVip,Gender,GivenName,Surname,Birthday,Height,Weight,CreditCardNumber", StringComparison.Ordinal))
            {
                continue;
            }

            ParseLine(line, fakeNames);
        }
    }

    private static void ParseLine(string line, List<FakeName> fakeNames)
    {
        var lineAsSpan = line.AsSpan();
        var fakeName = GetFakeName(ref lineAsSpan);
        if (fakeName != null)
        {
            fakeNames.Add(fakeName);
        }
    }

    private static FakeName GetFakeName(ref ReadOnlySpan<char> line)
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
