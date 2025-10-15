public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var number = new string([.. phoneNumber.Where(char.IsDigit)]);
        var prefixCode = 1;
        if (number.Length == 11)
        {
            prefixCode = number[0] - '0';
            number = number[1..];
        }
        int areaCode = number[0] - '0';
        int exchangeCode = number[3] - '0';
        if (number.Length != 10 || prefixCode != 1 || areaCode < 2 || exchangeCode < 2)
            throw new ArgumentException();
        return number;
    }
}