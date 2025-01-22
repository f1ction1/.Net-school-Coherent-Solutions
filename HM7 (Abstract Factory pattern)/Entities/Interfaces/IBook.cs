namespace Task7.Task7.Entities.Interfaces
{
    public interface IBook
    {
        string Title { get; set; }
        List<Author> Authors { get; set; }
    }
}
