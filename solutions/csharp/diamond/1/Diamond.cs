public static class Diamond
{
    public static string Make(char target)
    {
        if (target < 'A' || target > 'Z')
            throw new ArgumentOutOfRangeException(nameof(target), "Target must be an uppercase letter from A to Z.");
        var size = 2*(target - 'A') + 1;
        var rows = new string[size];
        for (char c = 'A'; c <= target; c++)
        {
            var row = new char[size];
            Array.Fill(row, ' ');
            int index = c - 'A';
            row[size / 2 - index] = c;
            row[size / 2 + index] = c;
            rows[index] = new string(row);
            rows[size - 1 - index] = new string(row);
        }
        return string.Join("\n", rows);
    }
}