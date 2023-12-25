using System.Text.RegularExpressions;

namespace FastestWaysInCSharp.RegularExpressions;

public static partial class EmailAddressValidator
{
    private const string _emailRegex = @"[a-z0-9]+@[a-z]+\.[a-z]{2,3}";

    private static readonly Regex _oldEmailRegex = new(_emailRegex);
    private static readonly Regex _oldEmailRegexCompiled = new(_emailRegex, RegexOptions.Compiled);

    public static bool Regex(in string emailAddress) => _oldEmailRegex.IsMatch(emailAddress);

    public static bool RegexCompiled(in string emailAddress) => _oldEmailRegexCompiled.IsMatch(emailAddress);

    [GeneratedRegex(_emailRegex)]
    private static partial Regex RegexSourceGen();

    public static bool RegexSourceGen(in string emailAddress) => RegexSourceGen().IsMatch(emailAddress);
}
