public static class Bob
{
    public static string Response(string statement)
    {
        statement = statement?.Trim() ?? string.Empty;
        var isSilence = string.IsNullOrEmpty(statement);
        if (isSilence) return "Fine. Be that way!";
        var isQuestion = statement.EndsWith("?");
        var isYell = statement.Any(char.IsLetter) && statement.ToUpper() == statement;
        return isYell && isQuestion
            ? "Calm down, I know what I'm doing!"
            : isYell
                ? "Whoa, chill out!"
                : isQuestion
                    ? "Sure."
                    : "Whatever.";
    }
}