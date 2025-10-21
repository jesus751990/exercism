class WeighingMachine
{
    public int Precision;
    public double TareAdjustment;
    public string DisplayWeight => $"{(Weight - TareAdjustment).ToString($"F{Precision}")} kg";

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

    public WeighingMachine(int precision)
    {
        Precision = precision;
        TareAdjustment = 5;
    }
}
