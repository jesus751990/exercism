public static class Hamming
{
    public static int Distance(string fs, string ss)
    {
        if (fs.Length != ss.Length)
            throw new ArgumentException();
        var distance = 0;
        for (var i = 0; i < fs.Length; i++)
        {
            if (fs[i] != ss[i])
                distance++;
        }
        return distance;
    }
}