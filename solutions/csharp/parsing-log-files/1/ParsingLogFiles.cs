using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        var garbledPattern = string.Join("|", garbledLogs.Select(g => "\\" + g + "\\"));
        var regx = new Regex($"^({garbledPattern}) (\\w+)");
        return regx.IsMatch(text);
    }

    public string[] SplitLogLine(string text)
    {
        var regx = new Regex(@"^<[=\-\^\*]{1,}>$");
        return [.. regx.Split(text).Where(t => !string.IsNullOrEmpty(t))];
    }

    public int CountQuotedPasswords(string lines) => lines.Split($"\"password\"").Length;

    public string RemoveEndOfLineText(string line) => line.Split("end-of-line").FirstOrDefault()!;

    public string[] ListLinesWithPasswords(string[] lines) => [.. lines.Where(l => l.Contains("\"password\"")).Select(l => $"--------:{l}")];

    private string[] garbledLogs =
    [
        "[TRC]",
        "[DBG]",
        "[INF]",
        "[WRN]",
        "[ERR]",
        "[FTL]",
    ];
}
