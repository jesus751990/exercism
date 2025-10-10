public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var letters = new HashSet<char>();
        foreach (var letter in word.ToLower())
        {
            if (char.IsLetter(letter) && !letters.Add(letter))
                return false;
        }
        return true;
    }
}
