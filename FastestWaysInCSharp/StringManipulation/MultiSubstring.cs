namespace FastestWaysInCSharp.StringManipulation;
public static class MultiSubstring
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "Mimic a real-life situation, when the variable is changing.")]
    private static string _text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

    public static string Substring()
    {
        string buffer = _text.Substring(0, 5);
        buffer += _text.Substring(28, 11);
        buffer += _text.Substring(116, 6);
        return buffer;
    }

    public static string CharArray()
    {
        char[] buffer = new char[22];
        buffer[0] = _text[0];
        buffer[1] = _text[1];
        buffer[2] = _text[2];
        buffer[3] = _text[3];
        buffer[4] = _text[4];
        buffer[5] = _text[28];
        buffer[6] = _text[29];
        buffer[7] = _text[30];
        buffer[8] = _text[31];
        buffer[9] = _text[32];
        buffer[10] = _text[33];
        buffer[11] = _text[34];
        buffer[12] = _text[35];
        buffer[13] = _text[36];
        buffer[14] = _text[37];
        buffer[15] = _text[38];
        buffer[16] = _text[116];
        buffer[17] = _text[117];
        buffer[18] = _text[118];
        buffer[19] = _text[119];
        buffer[20] = _text[120];
        buffer[21] = _text[121];
        return new string(buffer);
    }

    public static string CharArrayStackAlloc()
    {
        Span<char> buffer = stackalloc char[22];
        buffer[0] = _text[0];
        buffer[1] = _text[1];
        buffer[2] = _text[2];
        buffer[3] = _text[3];
        buffer[4] = _text[4];
        buffer[5] = _text[28];
        buffer[6] = _text[29];
        buffer[7] = _text[30];
        buffer[8] = _text[31];
        buffer[9] = _text[32];
        buffer[10] = _text[33];
        buffer[11] = _text[34];
        buffer[12] = _text[35];
        buffer[13] = _text[36];
        buffer[14] = _text[37];
        buffer[15] = _text[38];
        buffer[16] = _text[116];
        buffer[17] = _text[117];
        buffer[18] = _text[118];
        buffer[19] = _text[119];
        buffer[20] = _text[120];
        buffer[21] = _text[121];
        return new string(buffer);
    }

    public static string CharArrayStackAllocToString()
    {
        Span<char> buffer = stackalloc char[22];
        buffer[0] = _text[0];
        buffer[1] = _text[1];
        buffer[2] = _text[2];
        buffer[3] = _text[3];
        buffer[4] = _text[4];
        buffer[5] = _text[28];
        buffer[6] = _text[29];
        buffer[7] = _text[30];
        buffer[8] = _text[31];
        buffer[9] = _text[32];
        buffer[10] = _text[33];
        buffer[11] = _text[34];
        buffer[12] = _text[35];
        buffer[13] = _text[36];
        buffer[14] = _text[37];
        buffer[15] = _text[38];
        buffer[16] = _text[116];
        buffer[17] = _text[117];
        buffer[18] = _text[118];
        buffer[19] = _text[119];
        buffer[20] = _text[120];
        buffer[21] = _text[121];
        return buffer.ToString();
    }

    public static string StringCreate() =>
        string.Create(22, _text, (buffer, value) =>
        {
            buffer[0] = value[0];
            buffer[1] = value[1];
            buffer[2] = value[2];
            buffer[3] = value[3];
            buffer[4] = value[4];
            buffer[5] = value[28];
            buffer[6] = value[29];
            buffer[7] = value[30];
            buffer[8] = value[31];
            buffer[9] = value[32];
            buffer[10] = value[33];
            buffer[11] = value[34];
            buffer[12] = value[35];
            buffer[13] = value[36];
            buffer[14] = value[37];
            buffer[15] = value[38];
            buffer[16] = value[116];
            buffer[17] = value[117];
            buffer[18] = value[118];
            buffer[19] = value[119];
            buffer[20] = value[120];
            buffer[21] = value[121];
        });

    // Bad code. It's not cacheable.
    public static string StringCreateClosure() =>
        string.Create(22, _text, (buffer, value) =>
        {
            buffer[0] = _text[0];
            buffer[1] = _text[1];
            buffer[2] = _text[2];
            buffer[3] = _text[3];
            buffer[4] = _text[4];
            buffer[5] = _text[28];
            buffer[6] = _text[29];
            buffer[7] = _text[30];
            buffer[8] = _text[31];
            buffer[9] = _text[32];
            buffer[10] = _text[33];
            buffer[11] = _text[34];
            buffer[12] = _text[35];
            buffer[13] = _text[36];
            buffer[14] = _text[37];
            buffer[15] = _text[38];
            buffer[16] = _text[116];
            buffer[17] = _text[117];
            buffer[18] = _text[118];
            buffer[19] = _text[119];
            buffer[20] = _text[120];
            buffer[21] = _text[121];
        });

    // Reversing the assignation order allows the JIT to not add bounds checks.
    public static string StringCreateReverse() =>
        string.Create(22, _text, (buffer, value) =>
        {
            buffer[21] = value[121];
            buffer[20] = value[120];
            buffer[19] = value[119];
            buffer[18] = value[118];
            buffer[17] = value[117];
            buffer[16] = value[116];
            buffer[15] = value[38];
            buffer[14] = value[37];
            buffer[13] = value[36];
            buffer[12] = value[35];
            buffer[11] = value[34];
            buffer[10] = value[33];
            buffer[9] = value[32];
            buffer[8] = value[31];
            buffer[7] = value[30];
            buffer[6] = value[29];
            buffer[5] = value[28];
            buffer[4] = value[4];
            buffer[3] = value[3];
            buffer[2] = value[2];
            buffer[1] = value[1];
            buffer[0] = value[0];            
        });
    
    [System.Runtime.CompilerServices.SkipLocalsInit]
    public static string StringCreateReverseSkipLocalsInit() =>
        string.Create(22, _text, (buffer, value) =>
        {
            buffer[21] = value[121];
            buffer[20] = value[120];
            buffer[19] = value[119];
            buffer[18] = value[118];
            buffer[17] = value[117];
            buffer[16] = value[116];
            buffer[15] = value[38];
            buffer[14] = value[37];
            buffer[13] = value[36];
            buffer[12] = value[35];
            buffer[11] = value[34];
            buffer[10] = value[33];
            buffer[9] = value[32];
            buffer[8] = value[31];
            buffer[7] = value[30];
            buffer[6] = value[29];
            buffer[5] = value[28];
            buffer[4] = value[4];
            buffer[3] = value[3];
            buffer[2] = value[2];
            buffer[1] = value[1];
            buffer[0] = value[0];
        });

    public static string Zstring()
    {
        var textAsSpan = _text.AsSpan();

        using var sb = Cysharp.Text.ZString.CreateStringBuilder();
        sb.Append(textAsSpan.Slice(0, 5));
        sb.Append(textAsSpan.Slice(28, 11));
        sb.Append(textAsSpan.Slice(116, 6));

        // and build final string
        return sb.ToString();
    }
}
