public static class NucleotideCount
{
    private static string nucleotides = "ACGT";
    public static IDictionary<char, int> Count(string sequence) => sequence is not null && sequence.All(nucleotides.Contains)
        ? nucleotides.ToDictionary(n => n, n => sequence.Count(c => c == n))
        : throw new ArgumentException();
}