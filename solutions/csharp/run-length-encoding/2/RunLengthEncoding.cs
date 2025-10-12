using System;
using System.Text.RegularExpressions;
public static class RunLengthEncoding
{
    public static string Encode(string input)
        => Regex.Replace(input, @"(\D)\1+", i
            => i.Length.ToString() + i.Value[0]);

    public static string Decode(string input)
        => Regex.Replace(input, @"(\d+)(\D)", i
            => new String(i.Groups[2].Value[0], Int32.Parse(i.Groups[1].Value)));

}