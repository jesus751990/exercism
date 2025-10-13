public class Robot
{
    private static readonly Random Random = new();
    private static readonly HashSet<string> UsedNames = [];
    private string name;

    public string Name => name;

    public Robot() => name = GetUniqueName();

    public void Reset() => name = GetUniqueName();

    private string GetUniqueName()
    {
        var name = GetName();
        while (!UsedNames.Add(name))
            name = GetName();

        return name;
    }
    static string GetName() => $"{(char)Random.Next('A', 'Z' + 1)}{(char)Random.Next('A', 'Z' + 1)}{Random.Next(0, 1000):D3}";
}