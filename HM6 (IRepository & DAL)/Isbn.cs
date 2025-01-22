using System.Text.RegularExpressions;

namespace Task6
{
    public class Isbn
    {
        string _value;
        Regex _regexPattern1 = new Regex(@"\d{13}");
        Regex _regexPattern2 = new Regex(@"^\d{3}(-)\d(-)\d{2}(-)\d{6}(-)\d$");
        public string Value 
        {
            get { return _value; }
            private set { _value = value; }
        }
        public Isbn(string value)
        {
            if(value == null || !IsISBN(ref value))
            {
                throw new ArgumentException("Inappropriate ISBN!");
            }
            Value = value;
        }
        bool IsISBN(ref string isbn)
        {
            if (isbn.Length == 13 && _regexPattern1.IsMatch(isbn))
                return true;
            if (isbn.Length == 17 && _regexPattern2.IsMatch(isbn))
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
            return Value.Equals(item.Value);
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
