using Task7.Task7.Entities.Interfaces;

namespace Task6.Interfaces
{
    public interface IRepository
    {
        void Save(ICatalog catalog, string partPath);
    }
}
