using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var number = new string([.. phoneNumber.Where(char.IsDigit)]);
        var phoneNumberRgx = new Regex(@"^1?([2-9]\d\d[2-9]\d{6})$");
        var match = phoneNumberRgx.Match(number);
        return match.Success ? match.Groups[1].Value : throw new ArgumentException();
    }
}