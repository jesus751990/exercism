public class Robot
{
    private static readonly Random Random = new();
    private static readonly HashSet<string> UsedNames = [];
    private static readonly char[] Letters = [.. Enumerable.Range('A', 26).Select(x => (char)x)];
    private string name;

    public string Name => name;

    public Robot() => name = GenerateName();

    public void Reset() => name = GenerateName();

    private string GenerateName()
    {
        static string GetName() => $"{Letters[Random.Next(0, 26)]}{Letters[Random.Next(0, 26)]}{Random.Next(0, 1000):D3}";

        var name = GetName();
        while (!UsedNames.Add(name))
            name = GetName();

        return name;
    }
}