﻿namespace Task6
{
    public class Catalog
    {
        Dictionary<Isbn, Book> _books;
        public Dictionary<Isbn, Book> Books { get { return _books; } }
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
        public override bool Equals(object? obj)
        {
            var catalog = obj as Catalog;
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
