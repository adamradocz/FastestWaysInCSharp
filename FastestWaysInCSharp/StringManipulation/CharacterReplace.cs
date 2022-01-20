
namespace FastestWaysInCSharp.StringManipulation;

public static class CharacterReplace
{ 
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "Mimic a real-life situation, when the variable is changing.")]
    private static string _text = "Lorem ipsum dolor sit amet";

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
            buffer[25] = value[25];
            buffer[24] = value[24];
            buffer[23] = value[23];
            buffer[22] = value[22];
            buffer[21] = value[21];
            buffer[20] = value[20];
            buffer[19] = value[19];
            buffer[18] = value[18];
            buffer[17] = value[17];
            buffer[16] = value[16];
            buffer[15] = value[15];
            buffer[14] = value[14];
            buffer[13] = value[13];
            buffer[12] = value[12];
            buffer[11] = value[11];
            buffer[10] = value[10];
            buffer[9] = value[9];
            buffer[8] = value[8];
            buffer[7] = value[7];
            buffer[6] = value[6];
            buffer[5] = value[5];
            buffer[4] = value[4];
            buffer[3] = value[3];
            buffer[2] = value[2];
            buffer[1] = '#';
            buffer[0] = value[0];
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
