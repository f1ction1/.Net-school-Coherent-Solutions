namespace Task3
{
    internal interface IQueue<T> where T : struct
    {
        void Enqueue(T item);
        T Dequeue();
        bool IsEmpty();
    }
}
