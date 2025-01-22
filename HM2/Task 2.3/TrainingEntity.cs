namespace Task2
{
    internal class TrainingEntity
    {
        public string Description { get; set; }

        public TrainingEntity()
        {
            Description = string.Empty;
        }
        public TrainingEntity(string description)
        {
            Description = description;
        }
    }
}
