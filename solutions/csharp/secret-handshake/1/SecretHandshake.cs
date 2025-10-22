public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        var binary = Convert.ToString(commandValue, 2).Reverse().ToArray();
        var actions = new string[binary.Length];
        for (var i = 0; i < binary.Length; i++)
        {
            if (binary[i] == '1')
            {
                Actions.TryGetValue(i, out var action);
                if (!string.IsNullOrEmpty(action))
                    actions[i] = action;
            }
        }
        actions = [.. actions.Where(a => a is not null)];
        if (actions.Contains("reverse"))
            actions = [.. actions.Reverse().Where(a => a != "reverse")];
        return actions;
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
