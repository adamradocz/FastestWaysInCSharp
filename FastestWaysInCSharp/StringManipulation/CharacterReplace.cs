
namespace FastestWaysInCSharp.StringManipulation;

public static class CharacterReplace
{
    private const string _text = "Lorem ipsum dolor sit amet";

    public static string Substring()
    {
        string buffer = _text.Substring(0, 1);
        buffer += '#';
        buffer += _text.Substring(2);
        return buffer;
    }

    public static string StringCreate()
    {
        return string.Create(26, _text, (buffer, value) =>
        {
            buffer[25] = _text[25];
            buffer[24] = _text[24];
            buffer[23] = _text[23];
            buffer[22] = _text[22];
            buffer[21] = _text[21];
            buffer[20] = _text[20];
            buffer[19] = _text[19];
            buffer[18] = _text[18];
            buffer[17] = _text[17];
            buffer[16] = _text[16];
            buffer[15] = _text[15];
            buffer[14] = _text[14];
            buffer[13] = _text[13];
            buffer[12] = _text[12];
            buffer[11] = _text[11];
            buffer[10] = _text[10];
            buffer[9] = _text[9];
            buffer[8] = _text[8];
            buffer[7] = _text[7];
            buffer[6] = _text[6];
            buffer[5] = _text[5];
            buffer[4] = _text[4];
            buffer[3] = _text[3];
            buffer[2] = _text[2];
            buffer[1] = '#';
            buffer[0] = _text[0];
        });
    }

    public static string Unsafe()
    {
        unsafe
        {
            fixed (char* p = _text)
            {
                p[1] = '#';
            }
        }

        return _text;
    }
}
