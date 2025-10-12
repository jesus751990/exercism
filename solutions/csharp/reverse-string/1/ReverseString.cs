public static class ReverseString
{
    public static string Reverse(string input) => new([.. input.ToCharArray().Reverse()]);
}