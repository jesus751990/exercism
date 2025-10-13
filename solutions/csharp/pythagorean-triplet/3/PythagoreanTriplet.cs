public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum) => 
        from a in Enumerable.Range(1, sum / 3)
        from b in Enumerable.Range(a + 1, sum / 2)
        where a * a + b * b == (sum - a - b) * (sum - a - b)
        select (a, b, sum - a - b);
}