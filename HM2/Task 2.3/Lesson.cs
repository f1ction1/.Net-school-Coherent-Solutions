namespace Task2
{
    internal abstract class Lesson : TrainingEntity
    {
        public Lesson() { }
        public Lesson(string description) : base(description) { }
        public abstract Lesson Clone();   
    }
}
