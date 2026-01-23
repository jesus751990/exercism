public static class ResistorColorTrio
{
    public static string[] resColor = { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
    public static string[] units = { "ohms", "kiloohms", "megaohms", "gigaohms", "teraohms" };
    public static int color_code(string color)
    {
        var idx = Array.FindIndex(ResistorColorTrio.resColor, e => e == color);
        if (idx < 0) throw new Exception("invalid color");
        return idx;
    }
    public static string Label(string[] colors)
    {
        if (colors.Length < 2) throw new Exception("At least two colors need to be present");
        int num = (int)((color_code(colors[0]) * 10 + color_code(colors[1])) * Math.Pow(10, color_code(colors[2])));
        string unit = "";
        for (int i = 0; i < ResistorColorTrio.units.Length; i++, num /= 1000)
        {
            if (num / 1000.0 < 1.0)
            {
                unit = ResistorColorTrio.units[i];
                break;
            }
        }
        return $"{num} {unit}";
    }
}
