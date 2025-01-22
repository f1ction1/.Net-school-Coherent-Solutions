using Task7.Task7.Entities.Interfaces;
using Task7.Task7.EntitiesTask7.PressReleaseItems.Interfaces;

namespace Task7.Task7.LibraryBuilder.AbstractFactories.Interfaces
{
    public interface ILibraryAbstractFactory
    {
        ICatalog CreateCatalog();
        List<IPressReleaseItem> CreatePressReleaseItems();
    }
}
