namespace FastestWaysInCSharp.StringManipulation;

public static class ConvertStringToInt
{
    private static readonly string _textAsString = "1234567890";
    private const int _numericAsciiOffset = 48;

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
                result = 10 * result + (*str - 48);
                str++;
            }
        }
        return result;
    }
}
