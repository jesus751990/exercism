using System;
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location) => TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(appointmentDateDescription), GetTimeZoneInfo(location));

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        var offset = alertLevel switch
        {
            AlertLevel.Early => -24 * 60,
            AlertLevel.Standard => -105,
            AlertLevel.Late => -30,
            _ => throw new ArgumentOutOfRangeException(nameof(alertLevel), alertLevel, null)
        };
        return appointment.AddMinutes(offset);
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var timeZoneInfo = GetTimeZoneInfo(location);
        var sevenDaysEarlier = dt.AddDays(-7);
        return (timeZoneInfo.IsDaylightSavingTime(dt) != timeZoneInfo.IsDaylightSavingTime(sevenDaysEarlier));
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        DateTime.TryParse(dtStr, GetCultureInfo(location), DateTimeStyles.None, out var dt);
        return dt;
    }

    private static bool isWindows = OperatingSystem.IsWindows();

    private static CultureInfo GetCultureInfo(Location location)
    {
        var culture = location switch
        {
            Location.NewYork => "en-US",
            Location.London => "en-GB",
            Location.Paris => "fr-FR",
            _ => throw new ArgumentOutOfRangeException(nameof(location), location, null)
        };
        return CultureInfo.GetCultureInfo(culture);
    }

    private static TimeZoneInfo GetTimeZoneInfo(Location location) => TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneID(location));

    private static string GetTimeZoneID(Location location) => location switch
    {
        Location.NewYork => isWindows ? "Eastern Standard Time" : "America/New_York",
        Location.London => isWindows ? "GMT Standard Time" : "Europe/London",
        Location.Paris => isWindows ? "W. Europe Standard Time" : "Europe/Paris",
        _ => throw new ArgumentOutOfRangeException(nameof(location), location, null)
    };
}
