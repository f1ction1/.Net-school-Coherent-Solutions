namespace Task5
{
    public class Catalog
    {
        Dictionary<Isbn, Book> _books;
        public Catalog() 
        {
            _books = new Dictionary<Isbn, Book>();
        }
        public Catalog(Dictionary<Isbn, Book> books)
        {
            if (books == null)
                throw new ArgumentNullException("Books dictionary can't be null");
            _books = new Dictionary<Isbn, Book>(books);
        }
        public Book this[string isbn]
        {
            get 
            {
                if (isbn != null)
                    return _books[new Isbn(isbn)];
                else
                    throw new ArgumentNullException("Can't access due to null ISBN value!");
                
            }
        }
        public void AddBook(string isbn, Book book) 
        {
            if (isbn != null && book != null)
                _books.Add(new Isbn(isbn), new Book(book));
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
        public IEnumerable<string> GetAlphabeticallyTitles()
        {
            return _books.Values.Select(i => i.Title).OrderBy(i => i);
        }
        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            if (author == null)
                throw new ArgumentNullException("Author can't be a null string!");
            return _books.Values.Where(i => i.Authors.Contains(author)).OrderBy(i => i.PublicationDate);
        }
        public IEnumerable<(string,int)> GetNumberOfBooksEveryAuthor()
        {
            return _books.Values.SelectMany(book => book.Authors).GroupBy(author => author).Select(item => (item.Key, item.Count()));     
        }
    }
}
