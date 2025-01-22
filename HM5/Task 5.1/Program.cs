namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            SparseMatrix s1 = new SparseMatrix(4, 6);
            s1[2, 4] = 70;
            s1[2, 3] = 60;
            s1[1, 1] = 30;
            s1[0, 0] = 10;
            s1[0, 1] = 20;
            s1[3, 5] = 80;
            s1[2, 2] = 50;
            s1[1, 3] = 40;
            s1[3, 2] = 10;
            s1[1, 3] = 0;
            Console.WriteLine(s1);
            foreach (var i in s1)
            {
                Console.Write($"{i}, ");
            }
            var t = s1.GetNonzeroElements().ToList();
            foreach (var i in t)
            {
                Console.WriteLine($"({i.Item1}, {i.Item2}, {i.Item3})");
            }
            Console.WriteLine(s1.GetCount(10));
            Console.WriteLine(s1.GetCount(0));
        }
    }
}
