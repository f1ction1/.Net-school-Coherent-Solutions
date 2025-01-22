namespace Task6.Interfaces
{
    public interface IRepository
    {
        Catalog GetCatalog();
        void Save(Catalog catalog);
    }
}
