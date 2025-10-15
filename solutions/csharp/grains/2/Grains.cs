public static class Grains
{
    public static ulong Square(int n) => n switch
    {
        <= 0 or > 64 => throw new ArgumentOutOfRangeException(),
        _ => (ulong)Math.Pow(2, n - 1)
    };

    public static ulong Total() => Enumerable.Range(1, 64).Aggregate(0UL, (acc, x) => acc + Square(x));
}