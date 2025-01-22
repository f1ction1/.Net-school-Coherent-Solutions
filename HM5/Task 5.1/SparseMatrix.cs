namespace Task5
{
    internal class SparseMatrix : IEnumerable<long>
    {
        Dictionary<(int, int), long> _values;
        public int Rows { get; init; }
        public int Columns { get; init; }
        public SparseMatrix(int row, int col)
        {
            if(row <= 0 || col <= 0)
            {
                throw new ArgumentException("Dimensions can't be should be greater than zero");
            }
            Rows = row;
            Columns = col;
            _values = new Dictionary<(int, int), long>();
        }
        bool IsInRange(int i, int j)
        {
            return (i >= 0 && j >= 0 && i < Rows && j < Columns);
        }
        public long this[int i, int j]
        {
            get 
            {
                if (!IsInRange(i, j))
                {
                    throw new ArgumentException("Index is out of range!");
                }     
                return _values.Keys.Contains((i, j)) ? _values[(i, j)] : 0;
            }
            set
            {
                if (!IsInRange(i, j))
                {
                    throw new ArgumentException("Index is out of range!");
                }
                if(value != 0)
                {
                    if (_values.Keys.Contains((i, j)))
                    {
                        _values[(i, j)] = value;
                    }
                    else
                    {
                        _values.Add((i, j), value);
                    }
                } 
                else
                {
                    _values.Remove((i, j));
                }        
            }
        }
        public IEnumerable<(int, int, long)> GetNonzeroElements()
        {
            return _values.Select(elem => (elem.Key.Item1,elem.Key.Item2, elem.Value)).OrderBy(i => i.Item2).ThenBy(i => i.Item1);
        }
        public int GetCount(long x)
        {
            if(x == 0)
            {
                return (Rows*Columns) - _values.Count;
            }
            return _values.Count(p => p.Value == x);
        }
        public IEnumerator<long> GetEnumerator()
        {
            for(int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Columns; j++)
                {
                    yield return this[i,j];
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result.Append($"{this[i, j]} ");
                }
                result.AppendLine();
            }
            return result.ToString();
        }
    }
}
