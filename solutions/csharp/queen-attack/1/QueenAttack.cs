public class Queen
{
    public Queen(int row, int column)
    {
        if (row < 0 || row > 7)
            throw new ArgumentOutOfRangeException(nameof(row), "Row must be between 0 and 7.");
        if (column < 0 || column > 7)
            throw new ArgumentOutOfRangeException(nameof(column), "Column must be between 0 and 7.");
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen w, Queen b) => w.Row == b.Row || w.Column == b.Column || Math.Abs(w.Row - b.Row) == Math.Abs(w.Column - b.Column);

    public static Queen Create(int row, int column) => new(row, column);
}