public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        if (shiftKey < 0 || shiftKey > 26)
            throw new ArgumentOutOfRangeException(nameof(shiftKey), "Shift key must be between 0 and 26.");

        char[] result = new char[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                result[i] = (char)((((c + shiftKey) - offset) % 26) + offset);
            }
            else
                result[i] = c;
        }
        return new string(result);
    }
}