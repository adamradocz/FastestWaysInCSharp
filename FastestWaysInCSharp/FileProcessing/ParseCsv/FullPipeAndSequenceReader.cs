using FastestWaysInCSharp.FileProcessing.Model;
using System.Buffers;
using System.Buffers.Text;
using System.IO.Pipelines;
using System.Text;

namespace FastestWaysInCSharp.FileProcessing.ParseCsv;

public static class FullPipeAndSequenceReader
{
    private const byte _delimiterAsByte = (byte)',';
    private const byte _hyphenAsByte = (byte)'-';

    private static readonly byte[] _newLineAsByte = Encoding.UTF8.GetBytes("\r\n");
    private static readonly byte[] _header = Encoding.UTF8.GetBytes("Id,Guid,Gender,GivenName,Surname,City,StreetAddress,EmailAddress,Birthday,Height,Weight,CreditCardNumber,Domain");

    public static async Task<List<FakeName>> ParseAsync(string filePath)
    {
        var fakeNames = new List<FakeName>(100000);

        await using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 32768, FileOptions.SequentialScan);
        Pipe pipe = new();
        var fillPipe = FillPipeAsync(fileStream, pipe.Writer);
        var readPipe = ReadPipeAsync(pipe.Reader, fakeNames);
        await Task.WhenAll(fillPipe, readPipe);
        
        return fakeNames;
    }
    private static async Task FillPipeAsync(FileStream stream, PipeWriter writer)
    {
        await stream.CopyToAsync(writer.AsStream());
        await writer.CompleteAsync();
    }

    static async Task ReadPipeAsync(PipeReader reader, List<FakeName> fakeNames)
    {
        while (true)
        {
            var fileData = await reader.ReadAsync();

            // Convert to Buffer
            var fileDataBuffer = fileData.Buffer;

            var sequencePosition = ParseLine(fileDataBuffer, fakeNames);

            reader.AdvanceTo(sequencePosition, fileDataBuffer.End);

            if (fileData.IsCompleted)
            {
                break;
            }
        }

        await reader.CompleteAsync();
    }

    private static SequencePosition ParseLine(in ReadOnlySequence<byte> buffer, in List<FakeName> fakeNames)
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
        int delimiterAt = line.IndexOf(_delimiterAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, delimiterAt), out int id, out _);
        fakeName.Id = id;
        line = line.Slice(delimiterAt + 1);

        // Guid
        delimiterAt = line.IndexOf(_delimiterAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, delimiterAt), out Guid guid, out _);
        fakeName.Guid = guid;
        line = line.Slice(delimiterAt + 1);

        // Gender
        delimiterAt = line.IndexOf(_delimiterAsByte);
        fakeName.Gender = Encoding.UTF8.GetString(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // GivenName
        delimiterAt = line.IndexOf(_delimiterAsByte);
        fakeName.GivenName = Encoding.UTF8.GetString(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Surname
        delimiterAt = line.IndexOf(_delimiterAsByte);
        fakeName.Surname = Encoding.UTF8.GetString(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // City
        delimiterAt = line.IndexOf(_delimiterAsByte);
        fakeName.City = Encoding.UTF8.GetString(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // StreetAddress
        delimiterAt = line.IndexOf(_delimiterAsByte);
        fakeName.StreetAddress = Encoding.UTF8.GetString(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // EmailAddress
        delimiterAt = line.IndexOf(_delimiterAsByte);
        fakeName.EmailAddress = Encoding.UTF8.GetString(line.Slice(0, delimiterAt));
        line = line.Slice(delimiterAt + 1);

        // Birthday
        // Year
        int hyphenAt = line.IndexOf(_hyphenAsByte);
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
        delimiterAt = line.IndexOf(_delimiterAsByte);
        _ = Utf8Parser.TryParse(line.Slice(0, delimiterAt), out long creditCardNumber, out _);
        fakeName.CreditCardNumber = creditCardNumber;
        line = line.Slice(delimiterAt + 1);

        // Domain
        fakeName.Domain = new string(Encoding.UTF8.GetString(line));

        return fakeName;
    }
}