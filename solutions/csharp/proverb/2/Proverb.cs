public static class Proverb
{
    public static string[] Recite(string[] subjects) => subjects.Length == 0 ? []
        : [.. subjects.Zip(subjects.Skip(1)).Select(pair => $"For want of a {pair.First} the {pair.Second} was lost.")
            , $"And all for the want of a {subjects.First()}."];
}