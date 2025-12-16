public static class Forth
{
    private static Dictionary<string, string[]> defines = [];

    public static string Evaluate(string[] instructions)
    {
        if (instructions.Length == 0)
            return string.Empty;

        defines = [];
        var stackString = new Stack<string>(string.Join(" ", instructions).ToUpper().Split(" ").Reverse());
        var stackInt = new Stack<int>();

        while (stackString.Count != 0)
        {
            switch (stackString.Pop())
            {
                case var num when int.TryParse(num, out var n):
                    stackInt.Push(n);
                    break;
                case var key when defines.ContainsKey(key):
                    foreach (var define in defines[key].Reverse())
                        stackString.Push(define);
                    break;
                case "+":
                    stackInt.Push(Add(stackInt.Pop(), stackInt.Pop()));
                    break;
                case "-":
                    stackInt.Push(Sub(stackInt.Pop(), stackInt.Pop()));
                    break;
                case "*":
                    stackInt.Push(Mul(stackInt.Pop(), stackInt.Pop()));
                    break;
                case "/":
                    stackInt.Push(Div(stackInt.Pop(), stackInt.Pop()));
                    break;
                case "DUP":
                    stackInt.Push(stackInt.Peek());
                    break;
                case "DROP":
                    stackInt.Pop();
                    break;
                case "SWAP":
                    foreach (var item in new[] { stackInt.Pop(), stackInt.Pop() })
                        stackInt.Push(item);
                    break;
                case "OVER":
                    foreach (var item in new[] { stackInt.Pop(), stackInt.Peek() })
                        stackInt.Push(item);
                    break;
                case ":":
                    Define(ref stackString);
                    break;
                default:
                    throw new InvalidOperationException();

            }
        }
        return string.Join(" ", stackInt.Reverse());
    }

    private static int Add(int x, int y) => y + x;
    private static int Sub(int x, int y) => y - x;
    private static int Mul(int x, int y) => y * x;
    private static int Div(int x, int y) => x == 0 ? throw new DivideByZeroException() : y / x;

    private static void Define(ref Stack<string> stack)
    {
        var key = stack.Pop();
        if (int.TryParse(key, out int num))
            throw new InvalidOperationException();
        var values = new List<string>();
        var value = stack.Pop();
        while (value != ";")
        {
            values.Add(value);
            value = stack.Pop();
        }
        defines[key] = [.. values.SelectMany(k => defines.TryGetValue(k, out var define) ? define : [k])];
    }
}