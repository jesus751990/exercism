public static class SquareRoot
{
    public static int Root(int number)
    {
        if (number < 0)
            throw new ArgumentException("Cannot compute the square root of a negative number.");

        var x = number;
        var y = 1;
        var tol = 0.000001;
        while (x - y > tol)
        {
            x = (x + y) / 2;
            y = number / x;
        }
        return x;
    }
}
