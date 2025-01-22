using System.Text.RegularExpressions;
namespace Task5
{
    public class TesterClass
    {
        // Book
        public static void CheckBookClass(string title, DateTime? publicationDate, HashSet<string> authors)
        { 
            Book tmp = new Book(title, publicationDate, authors);
        }
        // Isbn
        public static bool CheckIsbnClassBool(string isbn)
        {
            if (isbn.Length == 13 && Regex.IsMatch(isbn, @"\d{13}"))
                return true;
            if (isbn.Length == 17 && Regex.IsMatch(isbn, @"^\d{3}(-)\d(-)\d{2}(-)\d{6}(-)\d$"))
            {
                return true;
            }
            return false;
        }
        public static void CheckIsbnClassException(string isbn)
        {
            Isbn tmp = new Isbn(isbn);
        }
    }
}
