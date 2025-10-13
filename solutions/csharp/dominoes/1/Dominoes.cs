public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        if (!dominoes.Any()) return true;
        if (dominoes.Count() == 1) return IsDouble(dominoes.First());
        var ds = dominoes.ToArray();
        for (int i = 1; i < ds.Length; i++)
        {
            if (CanPair(ds[0], ds[i]))
            {
                var nds = dominoes.Skip(1).ToArray();
                nds[i - 1] = Pair(ds[0], ds[i]);
                if (CanChain(nds)) 
                    return true;
            }
        }
        return false;
    }

    private static bool IsDouble((int, int) domino) => domino.Item1 == domino.Item2;

    private static bool CanPair((int, int) a, (int, int) b) => a.Item2 == b.Item1 || a.Item2 == b.Item2 || a.Item1 == b.Item1 || a.Item1 == b.Item2;

    private static (int, int) Pair((int, int) a, (int, int) b)
    {
        if (a.Item2 == b.Item1) return (a.Item1, b.Item2);
        if (a.Item2 == b.Item2) return (a.Item1, b.Item1);
        if (a.Item1 == b.Item1) return (a.Item2, b.Item2);
        return (a.Item2, b.Item1);
    }
}