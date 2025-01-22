namespace Task3
{
    internal static class ExtentionMethod
    {
        public static IQueue<T> Tail<T>(this IQueue<T> queue) where T : struct
        {
            if (queue == null) 
                throw new ArgumentNullException("Queue can't be null");
            if (!queue.IsEmpty())
            {
                var result = Activator.CreateInstance(queue.GetType(), queue) as IQueue<T>;
                if (result == null)
                    throw new Exception("Can't create an instance of queue");
                result.Dequeue();
                return result;
            }
            else
                throw new Exception("Queue is empty!");
            
        }
    }
}
