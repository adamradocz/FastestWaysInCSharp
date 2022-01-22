using System.Buffers.Text;
using System.Text;

namespace FastestWaysInCSharp.StringManipulation;

public class ParseByteArrayStringToInt
{
    private const int _numericAsciiOffset = 48;

    public static int GetStringIntParse(in ReadOnlySpan<byte> bytes) => int.Parse(Encoding.UTF8.GetString(bytes));

    public static int Utf8ParserTryParse(in ReadOnlySpan<byte> bytes)
    {
        _ = Utf8Parser.TryParse(bytes, out int number, out _);
        return number;
    }

    public static int CustomIntParse(in ReadOnlySpan<byte> bytes)
    {
        int result = 0;
        int byteArrayLenght = bytes.Length;
        for (int i = 0; i < byteArrayLenght; i++)
        {
            result = 10 * result + ((char)bytes[i] - _numericAsciiOffset);
        }
        return result;
    }
}
