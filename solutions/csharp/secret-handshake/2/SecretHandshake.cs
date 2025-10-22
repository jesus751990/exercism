public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        var binary = Convert.ToString(commandValue, 2).Reverse().ToArray();
        var handshake = new List<string>();
        for (var i = 0; i < binary.Length; i++)
        {
            if (binary[i] == '1')
            {
                Actions.TryGetValue(i, out var action);
                if (!string.IsNullOrEmpty(action))
                    handshake.Add(action);
            }
        }
        if (handshake.Contains("reverse"))
            handshake = [.. handshake.Where(a => a != Actions[4]).Reverse()];
        return [.. handshake];
    }

    private static Dictionary<int, string> Actions => new()
    {
            { 0, "wink" },
            { 1, "double blink" },
            { 2, "close your eyes" },
            { 3, "jump" },
            { 4, "reverse" }
        };
}
