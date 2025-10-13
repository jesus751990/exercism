public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        char Rotate(char c)
        {
            if (!char.IsLetter(c)) return c;
            int offset = char.IsLower(c) ? 'a' : 'A';
            return (char)(offset + ((c - offset + shiftKey) % 26));
        }

        return new([.. text.Select(Rotate)]);
    }
}