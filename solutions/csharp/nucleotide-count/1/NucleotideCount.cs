public static class NucleotideCount
{
    private static readonly char[] ValidNucleotides = { 'A', 'C', 'G', 'T' };

    public static IDictionary<char, int> Count(string sequence)
    {
        var sequenceArray = sequence.ToCharArray();
        foreach (var c in sequenceArray)
        {
            if (!ValidNucleotides.Contains(c))
                throw new ArgumentException("Invalid nucleotide in sequence");
        }

        var result = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };

        foreach (var nucleotide in sequence)
        {
            if (result.ContainsKey(nucleotide))
            {
                result[nucleotide]++;
            }
        }

        return result;
    }
}