public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old) => old.SelectMany(e => e.Value.Select(letter => (letter.ToLower(), e.Key))).ToDictionary();
}