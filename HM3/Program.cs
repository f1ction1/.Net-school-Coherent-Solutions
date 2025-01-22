namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IQueue<int> first = new Queue<int>(5);
            Console.WriteLine(first);
            first.Enqueue(5);
            first.Enqueue(1);
            first.Enqueue(3);
            Console.WriteLine(first);
            first.Enqueue(7);
            first.Enqueue(2);
            Console.WriteLine(first);
            try
            {
                first.Enqueue(100);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            first.Dequeue();
            first.Dequeue();
            first.Dequeue();
            first.Enqueue(1);
            Console.WriteLine(first);
            first.Dequeue();
            first.Dequeue();
            first.Dequeue();
            try
            {
                first.Dequeue();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(first.IsEmpty());
            IQueue<double> second = new Queue<double>(5);
            second.Enqueue(2.33);
            second.Enqueue(6.1);
            second.Enqueue(12.2);
            Console.WriteLine(second);
            second.Dequeue();
            Console.WriteLine(second);
            second.Enqueue(4);
            second.Enqueue(9);
            second.Enqueue(55);
            Console.WriteLine(second);
            var third = second.Tail();
            Console.WriteLine(third);
            third.Dequeue();
            second.Dequeue();
            Console.WriteLine(third);

        }
    }
}
