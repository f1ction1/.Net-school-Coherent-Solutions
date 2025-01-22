using System.Text.RegularExpressions;
namespace Task5
{
    public class Isbn
    {
        string _value;
        public Isbn(string value)
        {
            if(value == null || !IsISBN(ref value))
            {
                throw new ArgumentException("Inappropriate ISBN!");
            }
            _value = value;
        }
        bool IsISBN(ref string isbn)
        {
            if (isbn.Length == 13 && Regex.IsMatch(isbn, @"\d{13}"))
                return true;
            if (isbn.Length == 17 && Regex.IsMatch(isbn, @"^\d{3}(-)\d(-)\d{2}(-)\d{6}(-)\d$"))
            {
                isbn = ToSimpleFormatISBN(isbn);
                return true;
            }
            return false;
        }

        string ToSimpleFormatISBN(string isbn) 
        {
            return isbn.Replace("-", "");
        }

        public override bool Equals(object? obj)
        {
            var item = obj as Isbn;
            if(item == null)
                return false;
            return _value.Equals(item._value);
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}
