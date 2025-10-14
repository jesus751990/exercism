using System.Text.RegularExpressions;

enum LogLevel
{
    Unknown = 0,
    Trace,
    Debug,
    Info = 4,
    Warning,
    Error,
    Fatal = 42,
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        Regex rx = new(@"\[(.*?)\]");
        var log = rx.Match(logLine).Groups[1].Value;
        return logLevelMap.ContainsKey(log) ? logLevelMap[log] : LogLevel.Unknown;
    }

    public static string OutputForShortLog(LogLevel logLevel, string message) => $"{(int)logLevel}:{message}";

    private static readonly Dictionary<string, LogLevel> logLevelMap = new()
    {
        { "TRC", LogLevel.Trace },
        { "DBG", LogLevel.Debug },
        { "INF", LogLevel.Info },
        { "WRN", LogLevel.Warning },
        { "ERR", LogLevel.Error },
        { "FTL", LogLevel.Fatal }
    };
}
