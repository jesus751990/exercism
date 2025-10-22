public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        var result = new int[rows][];
        if (rows <= 0)
            return result;

        for (var i = 0; i < rows; i++)
        {
            result[i] = new int[i + 1];
            result[i][0] = 1;
            result[i][i] = 1;
            for (var j = 1; j < i; j++)
                result[i][j] = result[i - 1][j - 1] + result[i - 1][j];
        }
        return result;
    }
}