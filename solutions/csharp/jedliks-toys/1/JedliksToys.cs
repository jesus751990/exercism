class RemoteControlCar
{
    private int totalDistance;
    private int stepDistance = 20;
    private int batteryLevel;

    public RemoteControlCar()
    {
        totalDistance = 0;
        batteryLevel = 100;
    }

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {totalDistance} meters";
    }

    public string BatteryDisplay()
    {
        return batteryLevel > 0 
            ? $"Battery at {batteryLevel}%"
            : "Battery empty";
    }

    public void Drive()
    {
        if(batteryLevel > 0)
        {
            totalDistance += stepDistance;
            batteryLevel -= 1;
        }
    }
}
