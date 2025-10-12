static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        var rate = 0.0;
        rate = speed switch
        {
            0 => 0.0,
            1 or 2 or 3 or 4 => 1.0,
            5 or 6 or 7 or 8 => 0.9,
            9 => 0.8,
            10 => 0.77,
            _ => throw new ArgumentOutOfRangeException("Speed must be between 0 and 10"),
        };
        return rate;
    }

    public static double ProductionRatePerHour(int speed) => speed * 221 * SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed) => (int)(ProductionRatePerHour(speed) / 60);
}
