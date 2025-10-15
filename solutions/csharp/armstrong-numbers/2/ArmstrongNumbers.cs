public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number) => number.ToString().Select(x => Math.Pow(char.GetNumericValue(x), number.ToString().Length)).Sum() == number;
}