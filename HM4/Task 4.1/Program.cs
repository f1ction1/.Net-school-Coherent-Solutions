namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DiagonalMatrix<int> matrix1 = new DiagonalMatrix<int>(5);
            MatrixTracker<int> trackerForMatrix1 = new MatrixTracker<int>(matrix1);
            Console.WriteLine(matrix1);
            matrix1[0, 0] = 1;
            matrix1[1, 1] = 5;
            matrix1[2, 2] = 4;
            matrix1[3, 3] = 8;
            matrix1[4, 4] = 2;
            Console.WriteLine(matrix1);
            matrix1[1, 1] = 10;
            matrix1[1, 1] = 11;
            Console.WriteLine(matrix1);
            trackerForMatrix1.Undo();
            Console.WriteLine(matrix1);
            trackerForMatrix1.Undo();
            Console.WriteLine(matrix1);
            trackerForMatrix1.Undo();
            Console.WriteLine(matrix1);
            trackerForMatrix1.Undo();
            Console.WriteLine(matrix1);
            trackerForMatrix1.Undo();
            Console.WriteLine(matrix1);
            trackerForMatrix1.Undo();
            Console.WriteLine(matrix1);
            trackerForMatrix1.Undo();
            Console.WriteLine(matrix1);
            trackerForMatrix1.Undo();
            Console.WriteLine(matrix1);
            try
            {
                var test = new DiagonalMatrix<string>(4);
                var test2 = new DiagonalMatrix<string>(0);
                var test3 = new DiagonalMatrix<string>(-2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //matrix1.Size = 0; Read-Only
            try
            {
                var test = new DiagonalMatrix<double>(2);
                test[0, 1] = 2;
                test[0, 0] = 1;
                Console.WriteLine(test);
                test[0, -1] = 4;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var matrix2 = new DiagonalMatrix<string>(4);
            var trackerForMatrix2 = new MatrixTracker<string>(matrix2);
            Console.WriteLine(matrix2);
            matrix2[0, 0] = "Hello";
            matrix2[1, 1] = "Bye";
            matrix2[2, 2] = "Ok";
            matrix2[3, 3] = "dfsf";
            matrix2[3, 3] = "before";
            Console.WriteLine(matrix2);
            trackerForMatrix2.Undo();
            Console.WriteLine(matrix2);
            var matrix3 = new DiagonalMatrix<int>(5);
            matrix3[0, 0] = 12;
            matrix3[1, 1] = 1;
            matrix3[2, 2] = 0;
            matrix3[3, 3] = 2;
            matrix3[4, 4] = 0;
            Console.WriteLine(matrix1);
            Console.WriteLine(matrix3);
            var testAdd = matrix1.Add(matrix3, (a, b) => a + (b + 1));
            Console.WriteLine(testAdd);
        }
    }
}
