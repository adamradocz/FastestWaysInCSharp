using System.Buffers;
using System.Buffers.Text;
using System.Text;

namespace FastestWaysInCSharp.FileProcessing.ParseCsv.V4;

public static class FilePipeReaderAndSpan
{
    private const byte _delimiterAsByte = (byte)';';
    private const byte _newLineAsByte = (byte)'\n';
    private const byte _forwardSlashAsByte = (byte)'/';

    private static readonly byte[] _header = Encoding.UTF8.GetBytes("Id;Guid;Gender;GivenName;Surname;City;StreetAddress;EmailAddress;Birthday;Domain");

    public static void ParseLine(ReadOnlySpan<byte> line)
    {

        if (line[0] == 'M' && line[1] == 'N' && line[2] == 'O')
        {
            // SKIP MNO
            var delimiterAt = line.IndexOf(_delimiterAsByte);
            line = line.Slice(delimiterAt + 1);

            // Parse the line
            delimiterAt = line.IndexOf(_delimiterAsByte);
            Utf8Parser.TryParse(line.Slice(0, delimiterAt), out int elementId, out _);
            line = line.Slice(delimiterAt + 1);
            delimiterAt = line.IndexOf(_delimiterAsByte);
            Utf8Parser.TryParse(line.Slice(0, delimiterAt), out int vehicleId, out _);
            line = line.Slice(delimiterAt + 1);
            delimiterAt = line.IndexOf(_delimiterAsByte);
            Utf8Parser.TryParse(line.Slice(0, delimiterAt), out int term, out _);
            line = line.Slice(delimiterAt + 1);
            delimiterAt = line.IndexOf(_delimiterAsByte);
            Utf8Parser.TryParse(line.Slice(0, delimiterAt), out int mileage, out _);
            line = line.Slice(delimiterAt + 1);
            delimiterAt = line.IndexOf(_delimiterAsByte);
            Utf8Parser.TryParse(line.Slice(0, delimiterAt), out decimal value, out _);
            var valueHolder = new ValueHolderAsStruct(elementId, vehicleId, term, mileage, value);
        }
    }

    private static async IAsyncEnumerable<FakeName> ParseAsync(string filePath)
    {
        var reader = new FilePipeReader(filePath);

        while (true)
        {
            var result = await reader.ReadAsync();
            var buffer = result.Buffer;

            ParseLines(ref buffer);

            reader.AdvanceTo(buffer.Start, buffer.End);

            if (result.IsCompleted)
            {
                break;
            }
        }

        reader.Complete();
    }

    private static void ParseLines(ref ReadOnlySequence<byte> buffer)
    {
        var reader = new BufferReader(buffer);

        while (!reader.End)
        {
            var span = reader.UnreadSegment;
            int index = span.IndexOf(_newLineAsByte);
            int length = 0;

            if (index != -1)
            {
                length = index;
                ParseLine(span.Slice(0, index));
            }
            else
            {
                // We didn't find the new line in the current segment, see if it's 
                // another segment
                var current = reader.Position;
                var linePos = buffer.Slice(current).PositionOf(newLine);

                if (linePos == null)
                {
                    // Nope
                    break;
                }

                // We found one, so get the line and parse it
                var line = buffer.Slice(current, linePos.Value);
                ParseLine(lineParser, line);

                length = (int)line.Length;
            }

            // Advance past the line + the \n
            reader.Advance(length + 1);
        }

        // Update the buffer
        buffer = buffer.Slice(reader.Position);
    }

    private static void ParseLine(in ReadOnlySequence<byte> line)
    {
        // Lines are always small so we incur a small copy if we happen to cross a buffer boundary
        if (line.IsSingleSegment)
        {
            ParseLine(line.First.Span);
        }
        else if (line.Length < 256)
        {
            // Small lines we copy to the stack
            Span<byte> stackLine = stackalloc byte[(int)line.Length];
            line.CopyTo(stackLine);
            ParseLine(stackLine);
        }
        else
        {
            // Should be extremely rare
            var length = (int)line.Length;
            var buffer = ArrayPool<byte>.Shared.Rent(length);
            line.CopyTo(buffer);
            ParseLine(buffer.AsSpan(0, length));
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }
}
