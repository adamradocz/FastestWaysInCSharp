using System.Text.RegularExpressions;

namespace FastestWaysInCSharp.RegularExpressions;

public partial class EmailAddressValidator
{
    private const string EmailRegex = @"[a-z0-9]+@[a-z]+\.[a-z]{2,3}";

    private readonly Regex _oldEmailRegex = new(EmailRegex);
    private readonly Regex _oldEmailRegexCompiled = new(EmailRegex, RegexOptions.Compiled);

    public bool Regex(in string emailAddress) => _oldEmailRegex.IsMatch(emailAddress);

    public bool RegexCompiled(in string emailAddress) => _oldEmailRegexCompiled.IsMatch(emailAddress);

    [RegexGenerator(EmailRegex)]
    private partial Regex RegexSourceGen();

    public bool RegexSourceGen(in string emailAddress) => RegexSourceGen().IsMatch(emailAddress);
}
