public class Clock : IEquatable<Clock>
{
    private readonly int time;

    public Clock(int hours, int minutes)
    {
        time = (60 * hours + minutes) % (24 * 60);
        while (time < 0) time += 24 * 60;
    }

    public Clock Add(int minutesToAdd) => new(0, time + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => Add(-minutesToSubtract);

    public override string ToString() => $"{time / 60:D2}:{time % 60:D2}";

    public bool Equals(Clock? other) => other != null && other.time == time;
}
