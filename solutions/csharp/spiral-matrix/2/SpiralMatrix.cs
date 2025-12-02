public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int[,] matrix = new int[size, size];
        var value = 1;
        for (var i = 0; i < size;)
        {
            for (var j = i; j < size - i; j++)
                matrix[i, j] = value++;
            
            for (var j = i + 1; j < size - i; j++)
                matrix[j, size - i - 1] = value++;
            
            for (var j = size - i - 2; j >= i; j--)
                matrix[size - i - 1, j] = value++;
            
            for (var j = size - i - 2; j > i; j--)
                matrix[j, i] = value++;

            i++;
        }
        return matrix;
    }
}
