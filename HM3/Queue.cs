namespace Task3
{
    internal class Queue<T> : IQueue<T> where T : struct
    {
        private T[] _items;
        private int _tail;
        private int _head;
        private int _capacity;
        private int _count;
        public Queue(int capacity)
        {
            if(capacity > 0)
            {
                _items = new T[capacity];
                _tail = 0;
                _head = 0;
                _count = 0;
                _capacity = capacity;
            } else
            {
                throw new ArgumentException("Capacity can't be lower or equal zero!");
            }
        }
        public Queue(Queue<T> queue)
        {
            _capacity = queue._capacity;
            _items = new T[_capacity];
            Array.Copy(queue._items, _items, _capacity);
            _head = queue._head;
            _count = queue._count;
            _tail = queue._tail;
        }
        public bool IsEmpty()
        {
            return _count == 0;
        }
        public void Enqueue(T item)
        {
            if(_count != _capacity)
            {
                _items[_tail] = item;
                _count++;
                if (_tail == _capacity-1)
                    _tail = 0;
                else
                    _tail++;
            } else
            {
                throw new InvalidOperationException("The maximum capacity of the queue has been reached");
            }
        }
        public T Dequeue()
        {
            if (!IsEmpty())
            {
                T result = _items[_head];
                _count--;
                if (_head == _capacity - 1)
                    _head = 0;
                else
                    _head++;
                return result;
            }
            else
            {
                throw new InvalidOperationException("Can't remove an element from an empty queue");
            }
        }
        public override string ToString()
        {
            var result = new System.Text.StringBuilder();
            int index = _head;

            for (int i = 0; i < _count; i++)
            {
                result.Append(_items[index%_capacity]);
                if (i < _count - 1)
                {
                    result.Append("  ");
                }
                index++;
            }
            return result.ToString();
        }
    }
}
