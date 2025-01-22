using System.Text;
using Task7.Task7.Entities;
using Task7.Task7.Entities.Interfaces;
using Task7.Task7.EntitiesTask7.PressReleaseItems;

namespace Task7.Task7.EntitiesTask7
{
    public class PaperBook : Book, IBookClonable<PaperBook>  // What the best approach to use Composition or Inheritance ???
    {
        public List<Isbn> Isbns { get; set; }
        public Publisher Publisher { get; set; }
        public PaperBook(string title, DateTime? publicationDate, List<Author>? authors, List<Isbn> isbns, Publisher publisher) : base(title, publicationDate, authors)
        {
            Isbns = new List<Isbn>(isbns);
            Publisher = new Publisher(publisher.Value) ;
        }
        public PaperBook(PaperBook book) : base(book)
        {
            Isbns = new List<Isbn>(book.Isbns);
            Publisher = new Publisher(book.Publisher.Value);
        }
        public override string ToString()
        {
            StringBuilder isbns = new StringBuilder();
            foreach (var isbn in Isbns) 
            {
                isbns.Append($"  - {isbn}\n");
            }
            return $"{base.ToString()}\nPublisher: {Publisher.Value}\n Isbns:\n{isbns}";
        }
        public PaperBook Clone(PaperBook book)
        {
            if(book != null) 
            {
                return new PaperBook(book.Title, book.PublicationDate, book.Authors, book.Isbns, book.Publisher) ;
            }
            else
            {
                throw new ArgumentException("Book can't be null");
            }
        }
    }
}
