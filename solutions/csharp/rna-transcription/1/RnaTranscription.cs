public static class RnaTranscription
{
    public static string ToRna(string strand) => new([.. strand.ToRnaArray()]);

    private static IEnumerable<char> ToRnaArray(this string strand)
    {
        foreach (var c in strand)
        {
            switch (c)
            {
                case 'G':
                    yield return 'C';
                    break;
                case 'C':
                    yield return 'G';
                    break;
                case 'T':
                    yield return 'A';
                    break;
                case 'A':
                    yield return 'U';
                    break;
                default:
                    throw new ArgumentException("Invalid input DNA.");
            }
        }
    }
}