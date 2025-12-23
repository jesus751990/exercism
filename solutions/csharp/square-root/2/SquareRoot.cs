public static class SquareRoot
{
    public static int Root(int number)
    {
        var x = 0;
        while (x * x < number) x++;
        return x;
    }
}
