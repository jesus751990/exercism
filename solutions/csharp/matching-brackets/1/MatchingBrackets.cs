public static class MatchingBrackets
{
    private static char[] openingBrackets = ['(', '{', '['];
    private static char[] closingBrackets = [')', '}', ']'];

    public static bool IsPaired(string input)
    {
        var opening = new Stack<char>();
        foreach (var ch in input)
        {
            if (openingBrackets.Contains(ch))
                opening.Push(ch);
            else if (closingBrackets.Contains(ch) && (!opening.TryPop(out var op) || Array.IndexOf(openingBrackets, op) != Array.IndexOf(closingBrackets, ch)))
                return false;
        }

        return opening.Count == 0;
    }
}
