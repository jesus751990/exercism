class WeighingMachine
{
    public int Precision;

    public double TareAdjustment = 5;

    private double weight;
    public double Weight
    {
        get
        {
            return weight;
        }
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            weight = value;
        }
    }

    public string DisplayWeight => $"{(Weight - TareAdjustment).ToString($"F{Precision}")} kg";

    public WeighingMachine(int precision) => Precision = precision;
}
