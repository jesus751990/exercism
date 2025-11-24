using System.Text.RegularExpressions;
using Xunit.Internal;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        var garbledPattern = string.Join("|", garbledLogs);
        var regex = new Regex($@"^\[({garbledPattern})\].*");
        return regex.IsMatch(text);
    }

    public string[] SplitLogLine(string text)
    {
        var regex = new Regex(@"<[=\-\^*]+>");
        return [.. regex.Split(text)];
    }

    public int CountQuotedPasswords(string lines)
    {
        var regex = new Regex(@"""*password""", RegexOptions.IgnoreCase);
        return regex.Matches(lines).Count;
    }

    public string RemoveEndOfLineText(string line)
    {
        var regex = new Regex(@"end-of-line\d+");
        return regex.Replace(line, string.Empty);
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        var regex = new Regex(@"\bpassword\w+\b", RegexOptions.IgnoreCase);
        return [.. lines.Select(l => !regex.IsMatch(l) ? $"--------: {l}" : $"{regex.Match(l).Value}: {l}")];
    }

    private string[] garbledLogs =
    [
        "TRC",
        "DBG",
        "INF",
        "WRN",
        "ERR",
        "FTL",
    ];

    private Regex PasswordRegex => new(@"""*password""", RegexOptions.IgnoreCase);
}
