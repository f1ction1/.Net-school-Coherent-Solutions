namespace Task7.Task7.Entities.Interfaces
{
    public interface IBookClonable<T>
    { 
        T Clone(T obj);
    }
}
