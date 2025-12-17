public enum Schedule
{
    First = 1,
    Second = 8,
    Third = 15,
    Fourth = 22,
    Teenth = 13,
    Last = -6
}

public class Meetup
{
    private int _month;
    private int _year;
    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var day = schedule == Schedule.Last
            ? DateTime.DaysInMonth(_year, _month) + (int)schedule
            : (int)schedule;
        var date = new DateTime(_year, _month, day);
        return date.AddDays((dayOfWeek - date.DayOfWeek + 7) % 7);
    }
}