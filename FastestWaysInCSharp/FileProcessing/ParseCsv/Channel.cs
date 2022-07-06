using FastestWaysInCSharp.FileProcessing.Model;
using System.Buffers;
using System.Buffers.Text;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Channels;

namespace FastestWaysInCSharp.FileProcessing.ParseCsv;

public static class Channel
{
    private const byte _delimiterAsByte = (byte)',';
    private const byte _hyphenAsByte = (byte)'-';

    private static readonly byte[] _newLineAsByte = Encoding.UTF8.GetBytes("\r\n");
    private static readonly byte[] _header = Encoding.UTF8.GetBytes(Utilities.Data.CsvHeader);

    public static async Task<List<FakeName>> ParseAsync(string filePath)
    {
        var fakeNames = new List<FakeName>(100000);

        await using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 32768, FileOptions.SequentialScan);
        var reader = PipeReader.Create(fileStream);

        var channelOptions = new UnboundedChannelOptions() { SingleReader = true, SingleWriter = true };
        var channel = System.Threading.Channels.Channel.CreateUnbounded<string>(channelOptions);

        while (true)
        {
            var readResult = await reader.ReadAsync().ConfigureAwait(false);
            var buffer = readResult.Buffer;

            var actualPosition = ParseLine(buffer, fakeNames);

            reader.AdvanceTo(actualPosition, buffer.End);

            if (readResult.IsCompleted)
            {
                break;
            }
        }

        await reader.CompleteAsync().ConfigureAwait(false);

        return fakeNames;
    }

    private static SequencePosition ParseLine(in ReadOnlySequence<byte> buffer, List<FakeName> fakeNames)
    {
        var reader = new SequenceReader<byte>(buffer);
        while (reader.TryReadTo(out ReadOnlySpan<byte> line, _newLineAsByte))
        {
            var fakeName = GetFakeName(ref line);
            if (fakeName != null)
            {
                fakeNames.Add(fakeName);
            }
        }

        return reader.Position;
    }

    private static FakeName? GetFakeName(ref ReadOnlySpan<byte> line)
    {
        // Skip the header
        if (line.IndexOf(_header) >= 0)
        {
            return default;
        }

        var fakeName = new FakeName();

        // Id
        var delimiterAt = line.IndexOf(_delimiterAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, delimiterAt), out int id, out _);
        fakeName.Id = id;
        line = line.Slice(delimiterAt + 1);

        // Guid
        delimiterAt = line.IndexOf(_delimiterAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, delimiterAt), out Guid guid, out _);
        fakeName.Guid = guid;
        line = line.Slice(delimiterAt + 1);

        // IsVip
        delimiterAt = line.IndexOf(_delimiterAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, delimiterAt), out int isVip, out _);
        fakeName.IsVip = Convert.ToBoolean(isVip);
        line = line.Slice(delimiterAt + 1);

        // Gender
        delimiterAt = line.IndexOf(_delimiterAsByte);
        Span<char> gender = stackalloc char[1];
        _ = Encoding.UTF8.GetChars(line.Slice(0, delimiterAt), gender);
        fakeName.Gender = gender[0];
        line = line.Slice(delimiterAt + 1);

        // GivenName
        delimiterAt = line.IndexOf(_delimiterAsByte);
        fakeName.GivenName = Encoding.UTF8.GetString(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Surname
        delimiterAt = line.IndexOf(_delimiterAsByte);
        fakeName.Surname = Encoding.UTF8.GetString(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Birthday
        // Year
        var hyphenAt = line.IndexOf(_hyphenAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, hyphenAt), out int year, out _);
        line = line.Slice(hyphenAt + 1);

        // Month
        hyphenAt = line.IndexOf(_hyphenAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, hyphenAt), out int month, out _);
        line = line.Slice(hyphenAt + 1);

        // Day
        delimiterAt = line.IndexOf(_delimiterAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, delimiterAt), out int day, out _);
        fakeName.Birthday = new DateOnly(year, month, day);
        line = line.Slice(delimiterAt + 1);

        // Height
        delimiterAt = line.IndexOf(_delimiterAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, delimiterAt), out int height, out _);
        fakeName.Height = height;
        line = line.Slice(delimiterAt + 1);

        // Weight
        delimiterAt = line.IndexOf(_delimiterAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, delimiterAt), out float weight, out _);
        fakeName.Weight = weight;
        line = line.Slice(delimiterAt + 1);

        // CreditCardNumber
        _ = Utf8Parser.TryParse(line, out long creditCardNumber, out _);
        fakeName.CreditCardNumber = creditCardNumber;

        return fakeName;
    }
}
