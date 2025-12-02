public class CircularBuffer<T> : Queue<T>
{
    private readonly int _capacity;

    public bool IsFull => Count == _capacity;

    public CircularBuffer(int capacity) => _capacity = capacity;

    public T Read() => Count == 0 ? throw new InvalidOperationException("Buffer is empty.") : Dequeue();

    public void Write(T value)
    {
        if (IsFull)
            throw new InvalidOperationException("Buffer is full.");
        Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if(IsFull)
            Dequeue();
        Enqueue(value);
    }
}