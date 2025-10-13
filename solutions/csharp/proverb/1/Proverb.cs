public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        var lines = new List<string>();
        for (int i = 0; i < subjects.Length - 1; i++)
        {
            lines.Add(ForWantOf(subjects[i], subjects[i + 1]));
        }
        if (subjects.Length > 0)
            lines.Add(AllForWantOf(subjects[0]));

        return [.. lines];
    }

    private static string ForWantOf(string first, string second) => $"For want of a {first} the {second} was lost.";

    private static string AllForWantOf(string first) => $"And all for the want of a {first}.";
}