public static class EliudsEggs
{
    public static int EggCount(int encodedCount) => encodedCount.ToString("B").Count(c => c == '1');
}
