namespace Task2
{
    internal class PracticalLesson : Lesson
    {
        public string TaskCondition {  get; set; }
        public string TaskSolution { get; set;}

        public PracticalLesson()
        {
            TaskCondition = string.Empty;
            TaskSolution = string.Empty;
        }
        public PracticalLesson(string taskCondition, string taskSolution, string description) : base(description)
        {
            TaskCondition = taskCondition;
            TaskSolution = taskSolution;
        }
        public override Lesson Clone()
        {
            return new PracticalLesson(TaskCondition,TaskSolution, Description);
        }
        public override string ToString()
        {
            return $"Practical Lesson: {Description}; {TaskCondition}; {TaskSolution}";
        }
    }
}
