public static class ResistorColorTrio
{
    public static Dictionary<string, int> colorCodes = new Dictionary<string, int>
    {
        {"black", 0},
        {"brown", 1},
        {"red", 2},
        {"orange", 3},
        {"yellow", 4},
        {"green", 5},
        {"blue", 6},
        {"violet", 7},
        {"grey", 8},
        {"white", 9}
    };

    public static string Label(string[] colors)
    {
        int exponent = (colors.Length >= 3) ? colorCodes[colors[2]] : 0;
        double resistance = (10 * colorCodes[colors[0]] + colorCodes[colors[1]]) * Math.Pow(10, exponent);
        string prefix = "";

        if (resistance >= Math.Pow(10, 3) && resistance < Math.Pow(10, 6))
        {
            resistance /= Math.Pow(10, 3);
            prefix = "kilo";
        }
        else if (resistance >= Math.Pow(10, 6) && resistance < Math.Pow(10, 9))
        {
            resistance /= Math.Pow(10, 6);
            prefix = "mega";
        }
        else if (resistance >= Math.Pow(10, 9))
        {
            resistance /= Math.Pow(10, 9);
            prefix = "giga";
        }

        return $"{resistance} {prefix}ohms";
    }
}