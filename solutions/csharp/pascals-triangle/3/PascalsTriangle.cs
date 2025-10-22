public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows) =>
        Enumerable.Range(0, rows).Select(n => Enumerable.Range(0, n + 1).Select(k => PascalTriangleRow(n, k)));
    private static int PascalTriangleRow(int n, int k) =>
        Enumerable.Range(0, k).Aggregate(1, (acc, cur) => acc * (n - cur) / (cur + 1));
}