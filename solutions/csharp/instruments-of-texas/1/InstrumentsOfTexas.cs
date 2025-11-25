public class CalculationException(int operand1, int operand2, string message, Exception inner) : Exception(message, inner)
{
    public int Operand1 { get; } = operand1;
    public int Operand2 { get; } = operand2;
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator) => this.calculator = calculator;

    public string TestMultiplication(int x, int y)
    {
        try
        {
            Multiply(x, y);
            return "Multiply succeeded";
        }
        catch (Exception ex)
        {
            return x < 0 && y < 0
                ? $"Multiply failed for negative operands. {ex.Message}"
                : $"Multiply failed for mixed or positive operands. {ex.Message}";
        }
    }

    public void Multiply(int x, int y)
    {
        try
        {
            calculator.Multiply(x, y);
        }
        catch (OverflowException ex)
        {
            throw new CalculationException(x, y, ex.Message, ex);
        }
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
