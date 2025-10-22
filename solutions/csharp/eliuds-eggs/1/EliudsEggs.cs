public static class EliudsEggs
{
    public static int EggCount(int encodedCount) => Convert.ToString(encodedCount, 2).Select(c => c - '0').Sum();
}
