using Task6.DALEntities;
using Task6.Interfaces;
using System.Text.Json;
using Task7.Task7.Entities.Interfaces;

namespace Task6.Repositories
{
    public class JSONRepository : IRepository
    {
        private readonly string _path = $"C:\\Users\\Game Station\\Desktop\\Coherent Solutions\\HM's\\HM7\\JSONTest";
        //private readonly string _directoryName = "Catalog";
        public void Save(ICatalog catalog, string directoryName)
        {
            var authors = catalog.Books.Values.SelectMany(i => i.Authors).Distinct();
            foreach (var author in authors)
            {
                var books = catalog.Books.Where(catalogItem => catalogItem.Value.Authors.Contains(author)).Select(catalogItem => new DALCatalogItem() 
                {
                    Isbn = new DALIsbn() { Value = catalogItem.Key.Value },
                    Book = new DALBook()
                    {
                        Authors = catalogItem.Value.Authors.Select(author => new DALAuthor() { FirstName = author.FirstName, DateOfBirth = author.DateOfBirth }).ToList(),
                        Title = catalogItem.Value.Title
                    }
                });
                string jsonDirectory = $"{_path}\\{directoryName}";
                if (!Directory.Exists(jsonDirectory))
                {
                    Directory.CreateDirectory(jsonDirectory);
                }
                string fileName = $"{jsonDirectory}\\{author.FirstName}.json";
                string json = JsonSerializer.Serialize(books);
                File.WriteAllText(fileName, json);
            }
        }
    }
}
