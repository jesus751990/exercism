public class Deque<T>
{
    private List<T> items = [];

    public void Push(T value) => items.Add(value);

    public T Pop()
    {
        var last = items[^1];
        items.RemoveAt(items.Count - 1);
        return last;
    }

    public void Unshift(T value) => items.Insert(0, value);

    public T Shift()
    {
        var first = items[0];
        items.RemoveAt(0);
        return first;
    }
}