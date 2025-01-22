using System.Text;
using Task7.Task7.Entities.Interfaces;

namespace Task7.Task7.Entities
{
    public class Book : IBook, IBookClonable<Book>
    {
        string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                ArgumentNullException.ThrowIfNullOrEmpty(value);
                _title = value;
            }
        }
        public DateTime? PublicationDate { get; set; }
        public List<Author> Authors { get; set; }
        public Book(Book book)
        {
            if (book != null)
            {
                Title = book.Title;
                PublicationDate = book.PublicationDate;
                Authors = new List<Author>(book.Authors);
            }
            else
            {
                throw new ArgumentException("Book can't be null");
            }
        }
        public Book Clone(Book book)
        {
            if (book != null)
            {
                Book result = new Book(book.Title, book.PublicationDate, book.Authors);
                return result;
            }
            else
            {
                throw new ArgumentException("Book can't be null");
            }
        }
        public Book(string title, DateTime? publicationDate, List<Author>? authors)
        {
            Title = title;
            if (publicationDate != null && publicationDate > DateTime.Now)
                throw new ArgumentException("Publication date can't be in future!");
            Authors = authors == null ? new List<Author>() :new List<Author>(authors);
            PublicationDate = publicationDate;
        }
        public override string ToString()
        {
            StringBuilder authors = new StringBuilder();
            foreach (var author in Authors)
            {
                authors.Append($"  - {author}\n");
            }
            return $"Book: '{Title}', {PublicationDate?.ToShortDateString()}, Authors:\n{authors}";
        }
    }
}
