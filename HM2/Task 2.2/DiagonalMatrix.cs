namespace Task2
{
    internal class DiagonalMatrix
    {
        private int[] _elements;
        private int _size;
        public int Size 
        { 
            get { return _size; }
        }

        public DiagonalMatrix()
        {
            _size = 0;
            _elements = null;
        }
        public DiagonalMatrix(params int[] elements)
        {
            if(elements == null)
            {
                _size = 0;
                _elements = null; // null ?? or new int[0] ??
            }
            else
            {
                _size = elements.Length;
                _elements = new int[_size];
                Array.Copy(elements, _elements, _size);
            }
        }
        public DiagonalMatrix(DiagonalMatrix matrix)
        { 
            _size = matrix.Size;
            _elements = matrix.Size == 0 ? null : new int[_size];
            for(int i = 0; i < _size; i++)
            {
                _elements[i] = matrix[i, i];
            }

        }
        private bool CheckIndex(int i, int j)
        {
            if (i == j && _elements != null && i < _elements.Length && i >= 0)
                return true;
            return false;
        }
        public int this[int i, int j]
        {
            get 
            { 
                if(CheckIndex(i,j)) 
                    return _elements[i];
                return 0;
            }
            set 
            {
                if (CheckIndex(i, j))
                    _elements[i] = value;
            }
        }
        public int Track()
        {
            int sum = 0;
            if( _elements != null )
            {
                foreach(int element in _elements) 
                {
                    sum += element;
                }
            }
            return sum;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < _size; i++) 
            {
                for(int j = 0; j < _size; j++)
                {
                    if (i == j)
                        result += _elements[i] + " ";
                    else
                        result += "0 ";
                }
                result += "\n";
            }
            return result;
        }

        public override bool Equals(object? obj)
        {
            DiagonalMatrix tmp = obj as DiagonalMatrix;
            if (tmp == null) 
                return false;
            if(this.Size != tmp.Size)
                return false;
            else
            {
                for (int i = 0; i < _size; i++)
                {
                    if (_elements[i] != tmp[i, i])
                        return false;
                }
            }
            return true;
        }
    }
}
