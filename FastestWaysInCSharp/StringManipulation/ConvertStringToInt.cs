namespace FastestWaysInCSharp.StringManipulation;

public static class ConvertStringToInt
{
    private const int _numericAsciiOffset = 48;

    public static int IntParse(in string integerAsString) => int.Parse(integerAsString);

    public static int ConvertToInt32(in string integerAsString) => Convert.ToInt32(integerAsString);

    public static int CustomIntParse(in string integerAsString)
    {
        int result = 0;
        int stringLenght = integerAsString.Length;
        for (int i = 0; i < stringLenght; i++)
        {
            result = 10 * result + (integerAsString[i] - _numericAsciiOffset);
        }
        return result;
    }

    public unsafe static int CustomIntParseUnsafe(in string integerAsString)
    {
        int result = 0;
        fixed (char* v = integerAsString)
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
