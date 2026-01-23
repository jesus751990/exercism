public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if(inputBase < 2 || outputBase < 2)
            throw new ArgumentException("Input and output base must be at least 2.");
        var base10Value = ConvertFromBase(inputBase, inputDigits);
        return ConvertToBase(outputBase, base10Value);
    }

    private static int ConvertFromBase(int inputBase, int[] inputDigits)
    {
        int value = 0;
        int power = 1;
        for (int i = inputDigits.Length - 1; i >= 0; i--)
        {
            if(inputDigits[i] >= inputBase || inputDigits[i] < 0)
                throw new ArgumentException("All digits must be  andless than the input base and positives.");
            value += inputDigits[i] * power;
            power *= inputBase;
        }
        return value;
    }

    private static int[] ConvertToBase(int outputBase, int base10Value)
    {
        if (base10Value == 0) return [0];
        var digits = new List<int>();
        while (base10Value > 0)
        {
            digits.Add(base10Value % outputBase);
            base10Value /= outputBase;
        }
        digits.Reverse();
        return [.. digits];
    }
}