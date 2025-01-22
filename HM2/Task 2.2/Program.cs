namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            DiagonalMatrix matrix1 = new DiagonalMatrix(3,1,6,2);
            DiagonalMatrix matrix2 = new DiagonalMatrix(2,4,9);
            Console.WriteLine($"Matrix1:\n{matrix1}");
            Console.WriteLine($"Matrix1:\n{matrix2}");
            Console.WriteLine($"Size of matrix1: {matrix1.Size}");
            Console.WriteLine($"[1,1] of matrix1: {matrix1[1, 1]}");
            Console.WriteLine($"i and j not equal: {matrix1[0, 2]}");
            Console.WriteLine($"i or j out of bounds: {matrix1[-1,-2]}, {matrix1[matrix1.Size+1, 0]}, {matrix1[matrix1.Size,0]}");
            matrix1[0, 0] = 11;
            matrix1[0, 1] = 1;
            matrix1[-1,0] = 2;
            Console.WriteLine($"matrix1 after changes:\n{matrix1}");
            Console.WriteLine($"Sum of matrix1 elements on the main diagonal: {matrix1.Track()}");
            Console.WriteLine("\n--------------Equals() method test-----------------\n");
            Console.WriteLine(matrix1.Equals(matrix2));
            Console.WriteLine(matrix1.Equals(new DiagonalMatrix(11, 1, 6, 2)));
            Console.WriteLine(matrix1.Equals(1));
            Console.WriteLine(matrix1.Equals(new DiagonalMatrix(11, 1, 6, 2, 4)));
            Console.WriteLine(matrix1.Equals(null));
            Console.WriteLine(matrix1.Equals(new DiagonalMatrix()));
            Console.WriteLine(new DiagonalMatrix().Equals(new DiagonalMatrix())); //in my logic method return FALSE because there are no elements to compare
            Console.WriteLine("\n--------------Extension method test-----------------\n");
            Console.WriteLine(matrix2.AddDiagonalMatrix(matrix1));
            Console.WriteLine(matrix2.AddDiagonalMatrix(new DiagonalMatrix(1, 2, 3)));
            Console.WriteLine(matrix2.AddDiagonalMatrix(new DiagonalMatrix()));
            Console.WriteLine(new DiagonalMatrix().AddDiagonalMatrix(new DiagonalMatrix()));
            Console.WriteLine(new DiagonalMatrix().AddDiagonalMatrix(matrix1));
            try
            {
                DiagonalMatrix test = matrix2.AddDiagonalMatrix(null);
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
