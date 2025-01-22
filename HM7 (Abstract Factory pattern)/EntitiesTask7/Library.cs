using Task7.Task7.Entities.Interfaces;
using Task7.Task7.EntitiesTask7.PressReleaseItems.Interfaces;

namespace Task7.Task7.EntitiesTask7
{
    public class Library
    {
        public ICatalog Catalog { get; set; }
        public List<IPressReleaseItem> Items { get; set; }
        public Library(ICatalog catalog, List<IPressReleaseItem> items) 
        {
            ArgumentNullException.ThrowIfNull(catalog, "Catalog can't be null");
            ArgumentNullException.ThrowIfNull(items, "PressReleaseItems can't be null");
            Catalog = catalog;
            Items = items;
        }
    }
}
