public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        if (operation is null)
            throw new ArgumentNullException(nameof(operation));
        if(operation == string.Empty)
            throw new ArgumentException(nameof(operation));
        if (!operations.Contains(operation))
            throw new ArgumentOutOfRangeException(nameof(operation));
        if (operand2 == 0 && operation == "/")
            return "Division by zero is not allowed.";

        var result = operation switch
        {
            "+" => SimpleOperation.Addition(operand1, operand2),
            "*" => SimpleOperation.Multiplication(operand1, operand2),
            "/" => SimpleOperation.Division(operand1, operand2),
        };

        return $"{operand1} {operation} {operand2} = {result}";
    }

    private static string[] operations = { "+", "*", "/" };
}
