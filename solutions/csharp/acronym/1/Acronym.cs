public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var words = phrase.Split([' ', '-', '_'], StringSplitOptions.RemoveEmptyEntries);
        var acronym = new System.Text.StringBuilder();
        foreach (var word in words)
        {
            if (char.IsLetter(word[0]))
                acronym.Append(char.ToUpper(word[0]));
        }
        return acronym.ToString();
    }
}