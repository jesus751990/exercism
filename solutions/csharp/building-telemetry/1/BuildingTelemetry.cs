public class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = [];
    private int latestSerialNum = 0;

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors) => this.sponsors = sponsors;

    public string DisplaySponsor(int sponsorNum) => sponsors[sponsorNum];

    public bool GetTelemetryData(ref int serialNum, out int batteryPercentage, out int distanceDrivenInMeters)
    {
        latestSerialNum = serialNum;
        batteryPercentage = this.batteryPercentage;
        distanceDrivenInMeters = this.distanceDrivenInMeters;
        return true;
    }

    public static RemoteControlCar Buy() => new RemoteControlCar();
}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car) => this.car = car;

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        var data = car.GetTelemetryData(ref serialNum, out var batteryPercentage, out var distanceDrivenInMeters);
        return data ? $"Battery usage per meter: {batteryPercentage / (double)distanceDrivenInMeters}" : "no data";
    }
}
