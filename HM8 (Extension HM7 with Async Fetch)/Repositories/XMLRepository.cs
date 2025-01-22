using Task6.Interfaces;
using Task6.DALEntities;
using System.Xml.Serialization;
using Task7.Task7.Entities.Interfaces;

namespace Task6.Repositories
{
    internal class XMLRepository : IRepository
    {
        private readonly string _filePath = $"C:\\Users\\Game Station\\Desktop\\Coherent Solutions\\HM's\\HM7\\XMLFiles\\";
        public void Save(ICatalog catalog, string nameOfCatalog)
        {
            var dalCatalog = new DALCatalog()
            {
                Books = catalog.Books.Select(i => new DALCatalogItem()
                {
                    Book = new DALBook()
                    {
                        Authors = i.Value.Authors.Select(author => new DALAuthor() { FirstName = author.FirstName, DateOfBirth = author.DateOfBirth }).ToList(),
                        Title = i.Value.Title
                    },
                    Isbn = new DALIsbn() { Value = i.Key.Value }
                }).ToList()
            };
            string savePath = _filePath + nameOfCatalog + ".xml";
            using FileStream fs = new FileStream(savePath, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(DALCatalog));
            serializer.Serialize(fs, dalCatalog);
        }
    }
}
