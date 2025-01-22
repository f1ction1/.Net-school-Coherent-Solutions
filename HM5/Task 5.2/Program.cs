namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Book[] books = new Book[] 
            {
                new Book("gMyBook1", new DateTime(2023, 12, 20), new HashSet<string>() { "Author1OfBook1", "Author2OfBook1" }),
                new Book("xMyBook2", new DateTime(2023, 12, 21), new HashSet<string>() { "Author1OfBook2", "CommonAuthor1" }),
                new Book("aMyBook3", new DateTime(2023, 12, 25), new HashSet<string>() { "Author1OfBook3", "Author2OfBook3", "CommonAuthor2" }),
                new Book("zMyBook4", new DateTime(2023, 12, 28), new HashSet<string>() { "Author1OfBook4" }),
                new Book("bMyBook5", new DateTime(2023, 12, 30), new HashSet<string>() { "CommonAuthor2" }),
                new Book("2MyBook5", new DateTime(2023, 12, 10), new HashSet<string>() { "Author1OfBook6", "CommonAuthor1", "CommonAuthor2", "Author2OfBook6" })
            };
            Catalog catalog = new Catalog();
            catalog.AddBook("978-0-30-640615-7", new Book(books[0]));
            catalog.AddBook("978-1-56-619909-4", new Book(books[1]));
            catalog.AddBook("978-0-26-213472-9", new Book(books[2]));
            catalog.AddBook("978-0-54-501022-1", new Book(books[3]));
            catalog.AddBook("978-3-16-148410-0", new Book(books[4]));
            catalog.AddBook("978-0-74-327356-5", new Book(books[5]));

            List<string> test1 = catalog.GetAlphabeticallyTitles().ToList();
            List<Book> test2 = catalog.GetBooksByAuthor("CommonAuthor2").ToList();
            List<(string, int)> test3 = catalog.GetNumberOfBooksEveryAuthor().ToList();
        }
    }
}
