public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate) => Apply(collection, predicate, true);

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate) => Apply(collection, predicate, false);

    public static IEnumerable<T> Apply<T>(this IEnumerable<T> collection, Func<T, bool> predicate, bool result)
    {
        for (var i = 0; i < collection.Count(); i++)
            if (predicate(collection.ElementAt(i)) == result)
                yield return collection.ElementAt(i);
    }
}