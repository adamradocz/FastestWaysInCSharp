namespace FastestWaysInCSharp.StringManipulation;

public static class ConvertStringToInt
{
    private const int _numericAsciiOffset = 48;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "Mimic a real-life situation, when the variable is changing.")]
    private static string _textAsString = "1234567890";

    public static int IntParse() => int.Parse(_textAsString);

    public static int ConvertToInt32() => Convert.ToInt32(_textAsString);

    public static int CustomIntParse()
    {
        int result = 0;
        int stringLenght = _textAsString.Length;
        for (int i = 0; i < stringLenght; i++)
        {
            result = 10 * result + (_textAsString[i] - _numericAsciiOffset);
        }
        return result;
    }

    public unsafe static int CustomIntParseUnsafe()
    {
        int result = 0;
        fixed (char* v = _textAsString)
        {
            char* str = v;
            while (*str != '\0')
            {
                result = 10 * result + (*str - _numericAsciiOffset);
                str++;
            }
        }
        return result;
    }
}
