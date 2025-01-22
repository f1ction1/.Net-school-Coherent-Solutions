using Task7.Task7.Entities;
using Task7.Task7.Entities.Interfaces;
using Task7.Task7.EntitiesTask7;
using Task7.Task7.EntitiesTask7.PressReleaseItems;
using Task7.Task7.EntitiesTask7.PressReleaseItems.Interfaces;
using Task7.Task7.HelpClasses;
using Task7.Task7.LibraryBuilder.AbstractFactories.Interfaces;

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
            return new Catalog<EBook>(_data.Item2);
        }

        public List<IPressReleaseItem> CreatePressReleaseItems()
        {
            return new List<IPressReleaseItem>(_data.Item1);
        }
    }
}
