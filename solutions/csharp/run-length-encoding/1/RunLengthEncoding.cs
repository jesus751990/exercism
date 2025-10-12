using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        var chars = input.ToCharArray();
        var res = new StringBuilder();
        var occ = 0;
        char prev = chars.Length > 0 ? chars[0] : default;
        foreach (var c in chars)
        {
            if (c != prev)
            {
                if (occ > 1) res.Append(occ);
                res.Append(prev);
                occ = 1;
                prev = c;
            }
            else
                occ++;
        }
        if (occ > 1) res.Append(occ);
        if (prev != default) res.Append(prev);
        return res.ToString();
    }

    public static string Decode(string input)
    {
        var chars = input.ToCharArray();
        var res = new StringBuilder();
        var occ = 0;
        foreach (var c in chars)
        {
            if (char.IsDigit(c))
            {
                occ = occ * 10 + (c - '0');
            }
            else
            {
                if (occ == 0) occ = 1;
                res.Append(new string(c, occ));
                occ = 0;
            }
        }
        return res.ToString();
    }
}
