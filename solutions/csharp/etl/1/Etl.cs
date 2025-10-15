public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var result = new Dictionary<string, int>();
        foreach (var kvp in old)
        {
            foreach (var letter in kvp.Value)
            {
                result[letter.ToLower()] = kvp.Key;
            }
        }
        return result;
    }
}