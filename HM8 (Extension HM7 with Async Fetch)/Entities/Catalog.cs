using Task7.Task7.Entities.Interfaces;

namespace Task7.Task7.Entities
{
    public class Catalog<T> : ICatalog where T : IBook,  IBookClonable<T>
    {
        Dictionary<Isbn, T> _books;
        public Dictionary<Isbn, IBook> Books
        {
            get
            {
                return _books.ToDictionary(pair => pair.Key, pair => (IBook)pair.Value);
            }
        }

        public Catalog()
        {
            _books = new Dictionary<Isbn, T>();
        }
        public Catalog(Dictionary<Isbn, T> books)
        {
            if (books == null)
                throw new ArgumentNullException("Books dictionary can't be null");
            _books = new Dictionary<Isbn, T>(books);
        }
        public T this[string isbn]
        {
            get
            {
                if (isbn != null)
                    return _books[new Isbn(isbn)];
                else
                    throw new ArgumentNullException("Can't access due to null ISBN value!");

            }
        }
        public void AddBook(string isbn, T book)
        {
            if (isbn != null && book != null)
                _books.Add(new Isbn(isbn), book.Clone(book));
            else
                throw new ArgumentNullException("Can't add due to null ISBN or book value!");
        }
        public void RemoveBook(string isbn)
        {
            if (isbn != null)
                _books.Remove(new Isbn(isbn));
            else
                throw new ArgumentNullException("Can't remove due to null ISBN or book value!");
        }
        public override bool Equals(object? obj)
        {
            var catalog = obj as Catalog<T>;
            if (catalog == null)
                return false;
            return (_books.Count == catalog._books.Count) &&
                     _books.All(pair => catalog._books[pair.Key].ToString() == pair.Value.ToString());
        }
        public override int GetHashCode()
        {
            return _books.Keys.Sum(i => i.GetHashCode());
        }
    }
}
