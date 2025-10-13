public static class ResistorColorDuo
{
    private static readonly string[] Colors = 
    {
        "black", "brown", "red", "orange", "yellow", 
        "green", "blue", "violet", "grey", "white"
    };
    public static int Value(string[] colors) => Array.IndexOf(Colors, colors[0]) * 10 + Array.IndexOf(Colors, colors[1]);
}
