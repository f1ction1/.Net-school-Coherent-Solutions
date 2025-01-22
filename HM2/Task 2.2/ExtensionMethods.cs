namespace Task2
{
    internal static class ExtensionMethods
    {
        public static DiagonalMatrix AddDiagonalMatrix(this DiagonalMatrix matrix1, DiagonalMatrix matrix2)
        {
            int[] resultArray;
            if (matrix2 == null)
                throw new Exception("Matrix can't be null");
            if (matrix1.Size == 0 && matrix2.Size != 0)
                return new DiagonalMatrix(matrix2);
            if (matrix2.Size == 0 && matrix1.Size != 0)
                return new DiagonalMatrix(matrix1);
            if(matrix1.Size == 0 && matrix2.Size == 0)
                return new DiagonalMatrix();
            resultArray = new int[Math.Max(matrix1.Size,matrix2.Size)];
            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = matrix1[i,i] + matrix2[i,i];
            }
            return new DiagonalMatrix(resultArray);
        }
    }
}
