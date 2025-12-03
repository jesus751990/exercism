public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        var result = new List<uint>();
        foreach (var number in numbers)
        {
            var bytes = new List<uint>();
            uint n = number;
            do
            {
                uint byteValue = n & 0x7F; // Get the last 7 bits
                n >>= 7; // Shift right by 7 bits
                if (bytes.Count > 0)
                {
                    byteValue |= 0x80; // Set the continuation bit
                }
                bytes.Insert(0, byteValue); // Prepend to the list
            } while (n > 0);
            result.AddRange(bytes);
        }
        return [.. result];
    }

    public static uint[] Decode(uint[] bytes)
    {
        var result = new List<uint>();
        uint current = 0;
        int shift = 0;

        foreach (var b in bytes)
        {
            current |= (b & 0x7F) << shift;
            shift += 7;

            if ((b & 0x80) == 0)
            {
                result.Add(current);
                current = 0;
                shift = 0;
            }
        }

        return [.. result];
    }
}