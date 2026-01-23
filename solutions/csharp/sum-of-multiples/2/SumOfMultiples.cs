public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        var numbers = new HashSet<int>();
        foreach (var m in multiples.Where(m => m != 0))
        {
            var i = 1;
            while(m * i < max)
            {
                numbers.Add(m * i);
                i++;
            }
        }
        return numbers.Sum();
    }
}