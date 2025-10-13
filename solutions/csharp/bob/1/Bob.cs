public static class Bob
{
    public static string Response(string statement)
    {
        statement = statement?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(statement)) return "Fine. Be that way!";

        var question = statement.EndsWith("?");
        var yelling = statement.Any(char.IsLetter) && statement.ToUpper() == statement;
        return yelling && question 
            ? "Calm down, I know what I'm doing!" 
            : yelling 
                ? "Whoa, chill out!" 
                : question 
                    ? "Sure." 
                    : "Whatever.";
    }
}