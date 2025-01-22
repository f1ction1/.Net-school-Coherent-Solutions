namespace Task2
{
    internal class Lecture : Lesson
    {
        public string Topic {  get; set; }
        public Lecture(string topic, string description) : base(description)
        {
            Topic = topic;
        }
        public override Lesson Clone()
        {
            return new Lecture(Topic, Description);
        }
        public override string ToString()
        {
            return $"Lecture: {Description}; {Topic}";
        }
    }
}
