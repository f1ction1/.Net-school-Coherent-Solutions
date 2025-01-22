namespace Task4
{
    internal class DiagonalMatrix<T>
    {
        T[] _items;
        public int Size { get; private set; }
        public DiagonalMatrix(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(Size),"Can't be lower than zero");
            Size = size;
            _items = new T[Size];
        }

        public bool IsInRange(int i, int j)
        {
            return (i >= 0 && i < Size) && (j >= 0 && j < Size);
        }
        public T this[int i , int j]
        {
            get 
            {
                if (!IsInRange(i,j))
                    throw new IndexOutOfRangeException("Index out of range");
                return (i==j) ? _items[i] : default;
            }
            set
            {
                if (!IsInRange(i, j))
                    throw new IndexOutOfRangeException("Index out of range");
                if(value == null)
                    throw new ArgumentNullException("Value can't be null");
                if (i == j)
                {
                    if (!EqualityComparer<T>.Default.Equals(_items[i],value))
                    {
                        ElementChanged?.Invoke(this, new ElementChangedArgs<T>() { OldValue = _items[i], NewValue = value, Index = i });
                        _items[i] = value;
                    } 
                }
                    
            }
        }
        public event EventHandler<ElementChangedArgs<T>>? ElementChanged;
        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    result.Append(i == j ? $"{_items[i] } " : "0 ");
                }
                result.AppendLine();
            }
            return result.ToString();
        }
    }
}

