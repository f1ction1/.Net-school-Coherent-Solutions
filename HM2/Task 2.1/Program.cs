namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D p1 = new Point3D(new float[3] { 1.5f, 2, 10 }, 100);
            Point3D p2 = new Point3D(new float[3] { 4f, 16.7f, 2 }, 230);
            Point3D p3 = new Point3D();
            Console.WriteLine(p1.ToString());
            p1.X = 100;
            Console.WriteLine(p1.ToString());
            p1.Mass = -20;
            Console.WriteLine(p1.ToString());
            //
            Console.WriteLine(p3.IsZero());
            Console.WriteLine(p2.IsZero());
            Console.WriteLine($"Distance between p1 and p2: {p1.DistanceBetween(p2)}");
            try
            {
                Console.WriteLine($"Distance between p1 and null: {p1.DistanceBetween(null)}");
            }catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
