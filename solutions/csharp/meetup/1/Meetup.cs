public enum Schedule
{
    First = 1,
    Second = 8,
    Third = 15,
    Fourth = 22,
    Teenth = 13,
    Last = 25
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
        var date = new DateTime(_year, _month, (int)schedule, 12, 0, 0, DateTimeKind.Utc);
        var day = date.Day + (((int)dayOfWeek - (int)date.DayOfWeek)+7)%7;
        return new DateTime(_year,_month, day);
    }
}