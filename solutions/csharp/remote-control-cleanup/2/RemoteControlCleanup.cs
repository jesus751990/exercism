public class RemoteControlCar
{
    public Telemetry Telemetry { get; private set; }

    public RemoteControlCar() => Telemetry = new();

    public string CurrentSponsor => Telemetry.Sponsor;

    public string GetSpeed() => Telemetry.Speed.ToString();
}

public enum SpeedUnits
{
    MetersPerSecond,
    CentimetersPerSecond
}

public struct Speed
{
    public decimal Amount { get; }
    public SpeedUnits SpeedUnits { get; }

    public Speed(decimal amount, SpeedUnits speedUnits)
    {
        Amount = amount;
        SpeedUnits = speedUnits;
    }

    public override string ToString()
    {
        string unitsString = "meters per second";
        if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
        {
            unitsString = "centimeters per second";
        }

        return Amount + " " + unitsString;
    }
}

public class Telemetry
{
    public string Sponsor { get; internal set; } = string.Empty;
    public Speed Speed { get; internal set; }

    public void ShowSponsor(string sponsorName) => Sponsor = sponsorName;

    public void SetSpeed(decimal amount, string unitsString)
    {
        SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
        if (unitsString == "cps")
            speedUnits = SpeedUnits.CentimetersPerSecond;

        Speed = new Speed(amount, speedUnits);
    }
}
