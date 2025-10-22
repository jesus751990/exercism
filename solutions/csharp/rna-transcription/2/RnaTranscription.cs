public static class RnaTranscription
{
    public static string ToRna(string strand) => new([.. strand.Select(ToComplement)]);

    private static char ToComplement(this char nucleotide) => nucleotide switch
    {
        'G' => 'C',
        'C' => 'G',
        'T' => 'A',
        'A' => 'U',
        _ => throw new ArgumentException("Invalid nucleotide", nameof(nucleotide))
    };
}