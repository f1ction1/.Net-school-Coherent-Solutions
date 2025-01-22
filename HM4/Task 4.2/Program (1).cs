namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new RationalNumber(1,2));
            Console.WriteLine(new RationalNumber(1,-2));
            Console.WriteLine(new RationalNumber(-1,-2));
            Console.WriteLine(new RationalNumber(-1,2));
            RationalNumber r1 = new RationalNumber(2, 10);
            RationalNumber r2 = new RationalNumber(-10, 15);
            RationalNumber r3 = new RationalNumber(6, -3);
            Console.WriteLine(r1);
            Console.WriteLine(r2);
            Console.WriteLine(r3);
            Console.WriteLine($"Compare: {r1.CompareTo(r2)}");
            Console.WriteLine($"Compare: {new RationalNumber(1, 2).CompareTo(new RationalNumber(1, 2))}");
            Console.WriteLine($"Compare: {r2.CompareTo(r1)}");
            Console.WriteLine($"Add: {(r1 + r2)}");
            Console.WriteLine($"Substract: {(r1 - r2)}");
            Console.WriteLine($"Multiply: {(r1 * r2)}");
            Console.WriteLine($"Divide: {(r1 / r2)}");
            Console.WriteLine();
            RationalNumber test = 5;
            RationalNumber test2 = test * new RationalNumber(1, 2);
            Console.WriteLine(test2);
            Console.WriteLine((double)test2);
        }
    }
}
