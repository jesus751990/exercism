public class Anagram
{
    private string baseWord;

    public Anagram(string baseWord)
    {
        this.baseWord = baseWord;
    }

    public string[] FindAnagrams(string[] potentialMatches) => [.. potentialMatches.Where(IsAnagram)];

    private bool IsAnagram(string candidate)
    {
        if (candidate.ToLower() != baseWord.ToLower() && candidate.Length == baseWord.Length)
        {
            var bwChars = baseWord.ToLower().ToCharArray();
            var cChars = candidate.ToLower().ToCharArray();
            foreach (var bwc in bwChars)
            {
                var bwcOccurences = bwChars.Count(c => c == bwc);
                var ccOccurrences = cChars.Count(c => c == bwc);
                if (bwcOccurences != ccOccurrences)
                    return false;
            }
            return true;
        }
        return false;
    }
}