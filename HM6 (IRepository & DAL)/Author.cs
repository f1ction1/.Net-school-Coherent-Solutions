namespace Task6
{
    public class Author
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfTime { get; }

        const int _nameLengthLimitation = 200;
        public Author(string firstName, string lastName, DateTime dateOfTime)
        {
            if (firstName == null || firstName.Length > _nameLengthLimitation || lastName == null || lastName.Length > _nameLengthLimitation)
            {
                throw new ArgumentException("Inappropriate name!");
            }
            FirstName = firstName;
            LastName = lastName;
            DateOfTime = dateOfTime;
        }
        public override string ToString() => $"{FirstName} {LastName} {DateOfTime.ToShortDateString()}";
        public override int GetHashCode()
        {
            return $"{FirstName} {LastName}".GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            var author = obj as Author;
            if (author == null) 
            {
                return false;
            }
            return author.FirstName.Equals(FirstName) && author.LastName.Equals(LastName) && author.DateOfTime.Equals(DateOfTime);
        }
    }
}
