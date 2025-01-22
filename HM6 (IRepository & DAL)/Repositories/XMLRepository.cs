using Task6.Interfaces;
using Task6.DALEntities;
using System.Xml.Serialization;

namespace Task6.Repositories
{
    internal class XMLRepository : IRepository
    {
        private readonly string _filePath = $"C:\\Users\\Game Station\\Desktop\\Coherent Solutions\\HM's\\HM6\\XMLFiles\\Catalog.xml";
        public Catalog GetCatalog()
        {
            using FileStream fs = new FileStream(_filePath, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(DALCatalog));
            var dalCatalog = serializer.Deserialize(fs) as DALCatalog;
            var books = new Dictionary<Isbn, Book>();
            if (dalCatalog == null || dalCatalog.Books == null)
                throw new NullReferenceException("Can't create empty catalog (your XML catalog is empty)");
            foreach(var catalogItem in dalCatalog.Books)
            {
                if (catalogItem.Isbn == null || catalogItem.Isbn.Value == null || catalogItem.Book == null || catalogItem.Book.Title == null || catalogItem.Book.Authors == null) // to avoid warnings
                    throw new NullReferenceException("Some of catalog items is NULL");
                books.Add
                    (
                    new Isbn(catalogItem.Isbn.Value),
                    new Book(catalogItem.Book.Title, catalogItem.Book.PublicationDate, catalogItem.Book.Authors.Select(author => new Author(author.FirstName!, author.LastName!, author.DateOfTime)).ToHashSet())
                    );
            }
            return new Catalog(books);
        }
        public void Save(Catalog catalog)
        {
            var dalCatalog = new DALCatalog()
            {
                Books = catalog.Books.Select(i => new DALCatalogItem()
                {
                    Book = new DALBook()
                    {
                        Authors = i.Value.Authors.Select(author => new DALAuthor() { FirstName = author.FirstName, LastName = author.LastName, DateOfTime = author.DateOfTime }).ToHashSet(),
                        PublicationDate = i.Value.PublicationDate,
                        Title = i.Value.Title
                    },
                    Isbn = new DALIsbn() { Value = i.Key.Value }
                }).ToList()
            };
            using FileStream fs = new FileStream(_filePath, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(DALCatalog));
            serializer.Serialize(fs, dalCatalog);
        }
    }
}
