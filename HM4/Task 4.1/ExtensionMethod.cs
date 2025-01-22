namespace Task4
{
    static class ExtensionMethod
    {
        static public DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> matrix1, DiagonalMatrix<T> matrix2, Func<T,T,T> addition)
        {
            if (matrix2 == null)
                throw new ArgumentNullException("Matrix2 can't be null");
            if(addition == null)
                throw new ArgumentNullException("Addition can't be null");
            if (matrix1.Size != matrix2.Size)
                throw new ArgumentException("Matrices must have same size");
            var resultMatrix = new DiagonalMatrix<T>(matrix1.Size);
            for(int i = 0; i < resultMatrix.Size; i++)
            {

                resultMatrix[i,i] = addition(matrix1[i,i], matrix2[i, i]);
            }
            return resultMatrix;
        }
    }
}
