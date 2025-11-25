public class HighScores(List<int> list)
{
    private List<int> scores = list;

    public List<int> Scores() => scores;

    public int Latest() => scores[^1];

    public int PersonalBest() => scores.Max();

    public List<int> PersonalTopThree() => scores.OrderByDescending(s => s).Take(3).ToList();
}