using System.Globalization;
using System.Text.RegularExpressions;
using Xunit.Internal;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        if (string.IsNullOrEmpty(identifier))
            return identifier;

        var sanitized = identifier;
        if (identifier.Contains('-'))
        {
            var kebabIdentifier = string.Join("", identifier.Split("-").ToList().Select(kb => char.ToUpper(kb[0]) + kb[1..]));

            sanitized = char.ToLower(kebabIdentifier[0]) + kebabIdentifier[1..];
        }

        var result = string.Empty;
        sanitized.ForEach(c =>
        {
            if (char.IsControl(c))
                result += "CTRL";

            else if (char.IsWhiteSpace(c))
                result += '_';

            else if (char.IsLetter(c) && !Regex.Match(c.ToString(), "\\p{IsGreekandCoptic}").Success)
                result += c;
        });

        return result;
    }
}
