using System.Collections;

public static class Sieve
{
    public static IEnumerable<int> Primes(int max)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(max);
        var primes = new BitArray(max + 1, true);
        for (var i = 2; i <= max; i++)
        {
            if (!primes[i])
                continue;
            for (var j = i * 2; j <= max; j += i)
                primes[j] = false;
            yield return i;
        }
    }
}