namespace FastestWaysInCSharp.StringManipulation;

public class ConvertSubstringToInt
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "Mimic a real-life situation, when the variable is changing.")]
    private static string _text = "Lorem 69 ipsum dolor sit amet";

    private const int _numericAsciiOffset = 48;

    public static int SubstringIntParse()
    {
        string buffer = _text.Substring(6, 2);
        return int.Parse(buffer);
    }

    public static int SpanIntParse()
    {
        var textAsSpan = _text.AsSpan();
        var buffer = textAsSpan.Slice(6, 2);
        return int.Parse(buffer);
    }

    public static int SpanGenericCustomParse()
    {
        var textAsSpan = _text.AsSpan();
        var buffer = textAsSpan.Slice(6, 2);
        return GenericCustomIntParse(buffer);
    }

    private static int GenericCustomIntParse(in ReadOnlySpan<char> numberAsSpan)
    {
        int result = 0;
        int stringLenght = numberAsSpan.Length;
        for (int i = 0; i < stringLenght; i++)
        {
            result = 10 * result + (numberAsSpan[i] - _numericAsciiOffset);
        }
        return result;
    }

    public static int SpecificCustomIntParse()
    {
        int result = _text[6] - _numericAsciiOffset;
        result *= 10;
        result += _text[7] - _numericAsciiOffset;
        return result;
    }
}
