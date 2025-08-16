class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return [0, 2, 5, 3, 7, 8, 4];
    }

    public int Today()
    {
        return birdsPerDay[^1]; // Get the last element in the array
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[^1]++; // Increment the last element in the array
    }

    public bool HasDayWithoutBirds()
    {
        return Array.Exists(birdsPerDay, count => count == 0);
    }

    public int CountForFirstDays(int numberOfDays)
    {
        return numberOfDays > 0 && numberOfDays <= birdsPerDay.Length
            ? birdsPerDay.Take(numberOfDays).Sum()
            : throw new ArgumentOutOfRangeException(nameof(numberOfDays), "Number of days must be between 1 and the length of the array.");
    }

    public int BusyDays()
    {
        return birdsPerDay.Count(count => count >= 5);
    }
}
