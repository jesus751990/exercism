using System.Text;

public static class Raindrops
{
    public static string Convert(int number)
    {
        var sb = new StringBuilder();
        if (number % 3 == 0) sb.Append("Pling");
        if (number % 5 == 0) sb.Append("Plang");
        if (number % 7 == 0) sb.Append("Plong");
        if (number % 3 > 0 && number % 5 > 0 && number % 7 > 0) sb.Append(number);
        return sb.ToString();
    }
}