public static class LogAnalysis
{
    public static string SubstringAfter(this string logLine, string delimiter)
    {
        int index = logLine.IndexOf(delimiter);
        if (index == -1 || index + delimiter.Length >= logLine.Length)
        {
            return string.Empty;
        }
        return logLine[(index + delimiter.Length)..];
    }

    public static string SubstringBetween(this string logLine, string startDelimiter, string endDelimiter)
    {
        int startIndex = logLine.IndexOf(startDelimiter);
        if (startIndex == -1)
        {
            return string.Empty;
        }
        startIndex += startDelimiter.Length;
        int endIndex = logLine.IndexOf(endDelimiter, startIndex);
        if (endIndex == -1)
        {
            return string.Empty;
        }
        return logLine[startIndex..endIndex];
    }

    public static string Message(this string logLine) => logLine.SubstringAfter(": ").Trim();

    public static string LogLevel(this string logLine) => logLine.SubstringBetween("[", "]").Trim();
}