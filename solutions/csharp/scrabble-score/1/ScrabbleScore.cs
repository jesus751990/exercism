public static class ScrabbleScore
{
    public static int Score(string input)
    {
        var scrabble = new Dictionary<char[], int>
        {
            { new char[] {'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'}, 1 },
            { new char[] {'D', 'G'}, 2 },
            { new char[] {'B', 'C', 'M', 'P'}, 3 },
            { new char[] {'F', 'H', 'V', 'W', 'Y'}, 4 },
            { new char[] {'K'}, 5 },
            { new char[] {'J', 'X'}, 8 },
            { new char[] {'Q', 'Z'}, 10 },
        };
        var score = 0;
        foreach (var letter in input.ToUpper())
        {
            foreach (var (key, value) in scrabble)
            {
                if (key.Contains(letter))
                {
                    score += value;
                    break;
                }
            }
        }
        return score;
    }
}