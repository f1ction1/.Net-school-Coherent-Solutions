namespace Task5
{
    public class Book
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
                if(!IsValidTitle(value))
                {
                    throw new ArgumentException("Inappropriate title of the book!");
                }
                _title = value;
            }
        }
        public DateTime? PublicationDate { get; set; }
        public HashSet<string> Authors { get; set; }

        bool IsValidTitle(string title)
        {
            return !(string.IsNullOrEmpty(title));
        }
        public Book(Book book)
        {
            if(book != null)
            {
                Title = book.Title;
                PublicationDate = book.PublicationDate;
                Authors = new HashSet<string>(book.Authors);
            }
            else
            {
                throw new ArgumentException("Book can't be null");
            }
        }
        public Book(string title, DateTime? publicationDate, HashSet<string> authors)
        {
            Title = title;
            if(publicationDate != null && publicationDate > DateTime.Now)
                throw new ArgumentException("Publication date can't be in future!");
            if(authors == null)
                throw new ArgumentException("Authors Hashset can't be null");
            PublicationDate = publicationDate;
            Authors = new HashSet<string>(authors);
        }
        public override string ToString()
        {
            StringBuilder authors = new StringBuilder();
            foreach(var author in Authors)
            {
                authors.Append($"  - {author}\n");
            }
            return $"Book: '{Title}', {PublicationDate?.ToShortDateString()}, Authors:\n{authors}";
        }
    }
}
