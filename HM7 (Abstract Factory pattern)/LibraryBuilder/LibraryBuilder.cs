using Task7.Task7.EntitiesTask7;
using Task7.Task7.LibraryBuilder.AbstractFactories;
using Task7.Task7.LibraryBuilder.AbstractFactories.Interfaces;

namespace Task7.Task7.LibraryBuilder
{
    public class LibraryBuilder
    {
        ILibraryAbstractFactory factory = null;

        public Library Build(string type)
        {
            switch(type)
            {
                case "PaperBookLibrary": factory = new PaperBookLibraryFactory(); break;
                case "EBookLibrary": factory = new EBookLibraryAbstractFactory(); break;
            }
            return new Library(factory.CreateCatalog(), factory.CreatePressReleaseItems());
        }
    }
}
