public static class SimpleCalculator
{
    public static string Calculate(int op1, int op2, string? operation) => operation switch
    {
        "+" => $"{op1} {operation} {op2} = {op1 + op2}",
        "*" => $"{op1} {operation} {op2} = {op1 * op2}",
        "/" => op2 != 0 ? $"{op1} {operation} {op2} = {op1 / op2}" : "Division by zero is not allowed.",
        null => throw new ArgumentNullException(),
        "" => throw new ArgumentException(),
        _ => throw new ArgumentOutOfRangeException()
    };
}
