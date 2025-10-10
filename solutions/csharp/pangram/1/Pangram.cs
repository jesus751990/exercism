public static class Pangram
{
    public static bool IsPangram(string input)
    {
        var letters = new HashSet<char>("abcdefghijklmnopqrstuvwxyz");
        var lowerInput = input.ToLower();
        foreach (var l in letters)
        {
            if (!lowerInput.Any(c => c == l))
                return false;
        }
        return true;
    }
}
