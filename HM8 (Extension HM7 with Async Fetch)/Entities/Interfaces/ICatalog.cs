namespace Task7.Task7.Entities.Interfaces
{
    public interface ICatalog
    {
        Dictionary<Isbn, IBook> Books { get; }
    }
}
