public class Anagram
{
    private string baseWord;
    private readonly string baseWordSorted;

    public Anagram(string baseWord)
    {
        this.baseWord = baseWord;
        baseWordSorted = SortedLowerCase(baseWord);
    }

    public string[] FindAnagrams(string[] potentialMatches) => [.. potentialMatches.Where(IsAnagram)];

    private bool IsAnagram(string candidate) => !IsSameWord(baseWord, candidate) && SortedLowerCase(candidate) == baseWordSorted;

    private static bool IsSameWord(string word1, string word2) => word1.Equals(word2, StringComparison.OrdinalIgnoreCase);

    private static string SortedLowerCase(string input) => new([.. input.ToLower().OrderBy(c => c)]);
}