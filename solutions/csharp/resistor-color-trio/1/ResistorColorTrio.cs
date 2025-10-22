public static class ResistorColorTrio
{
    private static Dictionary<string, int> ColorResistors => new Dictionary<string, int>
    {
        {"black", 0},
        {"brown", 1},
        {"red", 2},
        {"orange", 3},
        {"yellow", 4},
        {"green", 5},
        {"blue",   6},
        {"violet", 7},
        {"grey",   8},
        {"white",  9 },
    };

    private static (long, string) GetPrefix(long value)
    {
        var multipliers = new (long threshold, string prefix)[]
        {
            (1_000_000_000, "giga"),
            (1_000_000, "mega"),
            (1_000, "kilo")
        };

        foreach (var (threshold, prefix) in multipliers)
        {
            if (value >= threshold)
                return (value / threshold, prefix);
        }

        return (value / 1, "");
    }

    public static string Label(string[] colors)
    {
        var value = ColorResistors[colors[0]] * 10 + ColorResistors[colors[1]];
        var multiplier = (int)Math.Pow(10, ColorResistors[colors[2]]);
        var (adjusted, prefix) = GetPrefix(value * multiplier);
        return $"{adjusted} {prefix}ohms";
    }
}
