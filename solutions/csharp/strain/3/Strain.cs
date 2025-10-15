public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate) => Apply(collection, predicate, true);
    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate) => Apply(collection, predicate, false);
    public static IEnumerable<T> Apply<T>(this IEnumerable<T> collection, Func<T, bool> predicate, bool result)
    {
        foreach (var e in collection)
            if (predicate(e) == result)
                yield return e;
    }
}