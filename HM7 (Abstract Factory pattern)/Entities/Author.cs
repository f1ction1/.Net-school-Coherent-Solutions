using System;
using System.Collections.Generic;
using System.Linq;
namespace Task7.Task7.Entities
{
    public class Author
    {
        public string FirstName { get; }
        //public string LastName { get; }
        public DateTime? DateOfBirth { get; }

        const int _nameLengthLimitation = 200;
        public Author(string firstName, DateTime? dateOfBirth)
        {
            if (firstName == null || firstName.Length > _nameLengthLimitation) //|| lastName == null || lastName.Length > _nameLengthLimitation)
            {
                throw new ArgumentException("Inappropriate name!");
            }
            FirstName = firstName;
            //LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
        public override string ToString() => $"{FirstName} {DateOfBirth?.ToShortDateString()}";
        public override int GetHashCode()
        {
            return $"{FirstName}".GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            var author = obj as Author;
            if (author == null)
            {
                return false;
            }
            return author.FirstName.Equals(FirstName) && author.DateOfBirth.Equals(DateOfBirth);
        }
    }
}
