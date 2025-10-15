public static class ScrabbleScore
{
    private static readonly Dictionary<string, int> Scores = new()
    {
        ["AEIOULNRST"] = 1,
        ["DG"] = 2,
        ["BCMP"] = 3,
        ["FHVWY"] = 4,
        ["K"] = 5,
        ["JX"] = 8,
        ["QZ"] = 10
    };

    public static int Score(string input) => input.Select(c => Scores.First(e => e.Key.Contains(char.ToUpper(c))).Value).Sum();
}