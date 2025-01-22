using Task6.Repositories;
using Task7.Task7.EntitiesTask7;
using Task7.Task7.LibraryBuilder;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LibraryBuilder builder = new LibraryBuilder();
            Library paperBookLibrary = builder.Build("PaperBookLibrary");
            Library eBookLibrary = builder.Build("EBookLibrary");
            XMLRepository xmlRepository = new XMLRepository();
            xmlRepository.Save(paperBookLibrary.Catalog, "Catalog1");
            xmlRepository.Save(eBookLibrary.Catalog, "Catalog2");
            JSONRepository jsonRepository = new JSONRepository();
            jsonRepository.Save(paperBookLibrary.Catalog, "Catalog1");
            jsonRepository.Save(eBookLibrary.Catalog, "Catalog2");
        }
    }
}
