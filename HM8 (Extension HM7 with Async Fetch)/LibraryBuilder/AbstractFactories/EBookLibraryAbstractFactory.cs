using Task7.Task7.Entities;
using Task7.Task7.Entities.Interfaces;
using Task7.Task7.EntitiesTask7;
using Task7.Task7.EntitiesTask7.PressReleaseItems;
using Task7.Task7.EntitiesTask7.PressReleaseItems.Interfaces;
using Task7.Task7.HelpClasses;
using Task7.Task7.LibraryBuilder.AbstractFactories.Interfaces;
using Task7.Task8.HelpClasses;

namespace Task7.Task7.LibraryBuilder.AbstractFactories
{
    internal class EBookLibraryAbstractFactory : ILibraryAbstractFactory
    {
        (List<ElectronicFormat>, Dictionary<Isbn, EBook>) _data;
        public EBookLibraryAbstractFactory()
        {
            _data = HandleCsv.GetEBooksData();
        }
        public ICatalog CreateCatalog()
        {
            List<Task> tasks = new List<Task>();
            EBookPageFetcher fetcher = new EBookPageFetcher();
            foreach (var book in _data.Item2)
            {
                tasks.Add(fetcher.FetchPagesNumberAsync(book.Value));
            }
            Task.WaitAll(tasks.ToArray());
            return new Catalog<EBook>(_data.Item2);
        }

        public List<IPressReleaseItem> CreatePressReleaseItems()
        {
            return new List<IPressReleaseItem>(_data.Item1);
        }
    }
}
