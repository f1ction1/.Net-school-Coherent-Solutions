using Task6.DALEntities;
using Task6.Interfaces;
using System.Text.Json;

namespace Task6.Repositories
{
    public class JSONRepository : IRepository
    {
        private readonly string _path = $"C:\\Users\\Game Station\\Desktop\\Coherent Solutions\\HM's\\HM6\\JSONTest";
        private readonly string _directoryName = "Catalog";
        public Catalog GetCatalog()
        {
            Dictionary<Isbn, Book> books = new Dictionary<Isbn, Book>();
            string getPath = $"{_path}\\{_directoryName}";
            string[] jsonFiles = Directory.GetFiles(getPath, "*.json");
            foreach (var filePath in jsonFiles)
            {
                string json = File.ReadAllText(filePath);
                var booksForAuthor = JsonSerializer.Deserialize<List<DALCatalogItem>>(json) ?? new List<DALCatalogItem>();
                foreach (var book in booksForAuthor)
                {
                    if (book.Isbn == null || book.Isbn.Value == null || book.Book == null || book.Book.Title == null || book.Book.Authors == null) // to avoid warnings
                        throw new NullReferenceException("Some of catalog items is NULL");
                    if (!books.Keys.Contains(new Isbn(book.Isbn.Value)))
                        books.Add(new Isbn(book.Isbn.Value), new Book(book.Book.Title, book.Book.PublicationDate, book.Book.Authors.Select(author => new Author(author.FirstName!, author.LastName!, author.DateOfTime)).ToHashSet()));
                }
            }
            return new Catalog(books);
            
        }
        public void Save(Catalog catalog)
        {
            var authors = catalog.Books.Values.SelectMany(i => i.Authors).Distinct();
            foreach (var author in authors)
            {
                var books = catalog.Books.Where(catalogItem => catalogItem.Value.Authors.Contains(author)).Select(catalogItem => new DALCatalogItem() 
                {
                    Isbn = new DALIsbn() { Value = catalogItem.Key.Value },
                    Book = new DALBook()
                    {
                        Authors = catalogItem.Value.Authors.Select(author => new DALAuthor() { FirstName = author.FirstName, LastName = author.LastName, DateOfTime = author.DateOfTime }).ToHashSet(),
                        PublicationDate = catalogItem.Value.PublicationDate,
                        Title = catalogItem.Value.Title
                    }
                });
                string jsonDirectory = $"{_path}\\{_directoryName}";
                if (!Directory.Exists(jsonDirectory))
                {
                    Directory.CreateDirectory(jsonDirectory);
                }
                string fileName = $"{jsonDirectory}\\{author.FirstName} {author.LastName}.json";
                string json = JsonSerializer.Serialize(books);
                File.WriteAllText(fileName, json);
            }
        }
    }
}
