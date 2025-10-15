public static class BottleSong
{
    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        var res = new List<string>();
        while (takeDown > 0)
        {
            res.Add(FirstVerse(startBottles));
            res.Add(FirstVerse(startBottles));
            res.Add(SecondVerse(startBottles));
            res.Add(ThirdVerse(startBottles));
            takeDown--;
            startBottles--;
            if (takeDown > 0)
                res.Add("");
        }
        return res;
    }

    private static Dictionary<int, string> Numbers() => new()
    {
        { 1, "One" },
        { 2, "Two" },
        { 3, "Three" },
        { 4, "Four" },
        { 5, "Five" },
        { 6, "Six" },
        { 7, "Seven" },
        { 8, "Eight" },
        { 9, "Nine" },
        { 10, "Ten" }
    };

    private static string Bottles(int n) => n switch
    {
        >= 2 => "bottles",
        1 => "bottle",
        _ => "no green bottles"
    };

    private static string FirstVerse(int n) => $"{Numbers()[n]} green {Bottles(n)} hanging on the wall,";

    private static string SecondVerse(int n) => $"And if one green {Bottles(1)} should accidentally fall,";

    private static string ThirdVerse(int n) => n - 1 > 0
        ? $"There'll be {Numbers()[n - 1].ToLower()} green {Bottles(n - 1)} hanging on the wall."
        : "There'll be no green bottles hanging on the wall.";
}
