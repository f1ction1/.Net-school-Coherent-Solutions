namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Training t1 = new Training("Training 1");
            t1.Add(new Lecture("Description 1", "Lecture 1"));
            t1.Add(new Lecture("Description 2", "Lecture 2"));
            t1.Add(new PracticalLesson("Lesson 1", "Task Condition 1", "Task Solution 1"));
            Console.WriteLine(t1);
            Console.WriteLine(t1.IsPractical());
            Training t2 = new Training("Training 2", new PracticalLesson[] { new PracticalLesson("Lesson 1", "Task Condition 1", "Task Solution 1") });
            Console.WriteLine(t2);
            Console.WriteLine(t2.IsPractical());
            Training t3 = t1.Clone();
            Console.WriteLine(t3);
        }
    }
}
