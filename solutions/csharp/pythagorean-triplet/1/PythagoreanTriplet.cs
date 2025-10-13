public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        for (var a = 0; a < sum; a++)
        {
            for (var b = a + 1; b < sum; b++)
            {
                var c = sum - a - b;
                if (c <= b) break;
                if (a * a + b * b == c * c) yield return (a, b, c);
            }
        }
    }
}