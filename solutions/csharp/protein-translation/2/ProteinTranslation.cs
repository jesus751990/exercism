public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        var proteins = new List<string>();
        for (int i = 0; i < strand.Length; i += 3)
        {
            var codon = strand.Substring(i, 3);
            if (CodonToProtein().TryGetValue(codon, out var protein))
                proteins.Add(protein);
            else if (codon == "UAA" || codon == "UAG" || codon == "UGA")
                break;
        }
        return [.. proteins];
    }

    private static Dictionary<string, string> CodonToProtein() => new()
        {
            { "AUG", "Methionine"},
            { "UUU", "Phenylalanine"},
            { "UUC", "Phenylalanine"},
            { "UUA", "Leucine"},
            { "UUG", "Leucine"},
            { "UCU", "Serine"},
            { "UCC", "Serine"},
            { "UCA", "Serine"},
            { "UCG", "Serine" },
            { "UAU", "Tyrosine"},
            { "UAC", "Tyrosine" },
            { "UGU", "Cysteine"},
            { "UGC", "Cysteine" },
            { "UGG", "Tryptophan" }
        };
}