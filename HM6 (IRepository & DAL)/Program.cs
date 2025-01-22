using Task6.Repositories;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Author[] authors = new Author[]
            {
                new Author("James", "Clear", new DateTime(1986, 1, 22)),            //0
                new Author("Robert C.", "Martin", new DateTime(1952, 12, 5)),       //1
                new Author("Micah", "Martin", new DateTime(1962, 9, 20)),           //2
                new Author("Martin", "Fowler", new DateTime(1963, 12, 18)),         //3
                new Author("Kent", "Beck", new DateTime(1961, 3, 31)),              //4
                new Author("John", "Brant", new DateTime(1794, 9, 27)),             //5
                new Author("William", "Opdyke", new DateTime(1958, 10, 13)),        //6
                new Author("Don", "Roberts", new DateTime(1959, 1, 10)),            //7
                new Author("Cynthia", "Andres", new DateTime(1963, 8, 22)),         //8
                new Author("Erich", "Gamma", new DateTime(1961, 3, 13)),            //9
                new Author("Richard", "Helm", new DateTime(1971, 7, 19)),           //10
                new Author("Ralph", "Johnson", new DateTime(1951, 7, 4)),           //11
                new Author("John", "Vlissides", new DateTime(1961, 8, 2)),          //12
            };

            Book[] books = new Book[]
            {
                new Book("Atomic Habits", new DateTime(2018, 10, 24), new HashSet<Author>() { authors[0] }),
                new Book("Clean Code: A Handbook of Agile Software Craftsmanship", new DateTime(2006, 7, 20), new HashSet<Author>() { authors[1] }),
                new Book("Agile Principles, Patterns, and Practices in C#", new DateTime(2023, 12, 25), new HashSet<Author>() { authors[1], authors[2] }),
                new Book("Refactoring: Improving the Design of Existing Code (2nd Edition)", new DateTime(2018, 11, 19), new HashSet<Author>() { authors[3], authors[4], authors[5], authors[6], authors[7]}),
                new Book("Patterns of Enterprise Application Architecture", new DateTime(2002, 11, 5), new HashSet<Author>() { authors[3] }),
                new Book("Extreme Programming Explained: Embrace Change (2nd Edition)", new DateTime(2004, 11, 17), new HashSet<Author>() { authors[4], authors[8]}),
                new Book("Design Patterns: Elements of Reusable Object-Oriented Software", new DateTime(1994, 10, 31), new HashSet<Author>() { authors[9], authors[10], authors[11], authors[12]})
            };
            Catalog catalog = new Catalog();
            catalog.AddBook("9781847941831", new Book(books[0]));
            catalog.AddBook("9780132350884", new Book(books[1]));
            catalog.AddBook("9780131857254", new Book(books[2]));
            catalog.AddBook("9780134757599", new Book(books[3]));
            catalog.AddBook("9780321127426", new Book(books[4]));
            catalog.AddBook("9780321278654", new Book(books[5]));
            catalog.AddBook("9780201633610", new Book(books[6]));

            XMLRepository xmlRepository = new XMLRepository();
            xmlRepository.Save(catalog);
            var testXML = xmlRepository.GetCatalog();
            Console.WriteLine($"Is equal? -> {catalog.Equals(testXML)}");

            JSONRepository jsonRepository = new JSONRepository();
            jsonRepository.Save(catalog);
            var testJSON = jsonRepository.GetCatalog();
            Console.WriteLine($"Is equal? -> {catalog.Equals(testXML)}");
        }
    }
}
