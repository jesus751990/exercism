public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(number, 1);
        var sumOfFactors = SumOfFactors(number);
        return sumOfFactors switch
        {
            _ when sumOfFactors == number => Classification.Perfect,
            _ when sumOfFactors > number => Classification.Abundant,
            _ => Classification.Deficient
        };
    }

    private static int SumOfFactors(int number) => GetFactors(number).Sum();

    private static IEnumerable<int> GetFactors(int number) => Enumerable.Range(1, number / 2).Where(i => number % i == 0);
}
