public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var digist = number.ToString().ToArray();
        var result = 0;
        foreach (var d in digist)
            result += (int)Math.Pow(d - '0', digist.Length);
        return result == number;
    }
}