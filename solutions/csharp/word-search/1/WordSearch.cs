public class WordSearch
{
    private readonly string[] rows;
    public WordSearch(string grid) => rows = grid.Split('\n');
    public (int, int)[] directions =
    [
        (0, 1),   // → right
        (0, -1),  // ← left
        (1, 0),   // ↓ down
        (-1, 0),  // ↑ up
        (1, 1),   // ↘ down-right
        (1, -1),  // ↗ up-right
        (-1, 1),  // ↙ down-left
        (-1, -1)  // ↖ up-left
    ];
    public Dictionary<string, ((int, int), (int, int))?> Search(string[] words) =>
        words.ToDictionary(
            w => w,
            word =>
                (
                    from r in Enumerable.Range(0, rows.Length)
                    from c in Enumerable.Range(0, rows[0].Length)
                    from d in directions
                    where DoesWordFound(r, c, d, word)
                    select (((int, int), (int, int))?)
                        (
                            (c + 1, r + 1),
                            (
                                c + d.Item2 * (word.Length - 1) + 1,
                                r + d.Item1 * (word.Length - 1) + 1
                            )
                        )
                ).FirstOrDefault()
        );
    private bool DoesWordFound(int r, int c, (int, int) d, string word)
    {
        var (dr, dc) = d;
        return Enumerable
            .Range(0, word.Length)
            .All(i =>
            {
                int newR = r + dr * i;
                int newC = c + dc * i;
                return newR >= 0 && newR < rows.Length && newC >= 0 && newC < rows[0].Length && rows[newR][newC] == word[i];
            });
    }
}