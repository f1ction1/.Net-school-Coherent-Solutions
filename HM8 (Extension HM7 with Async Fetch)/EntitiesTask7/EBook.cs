using System.Text;
using Task7.Task7.Entities;
using Task7.Task7.Entities.Interfaces;
using Task7.Task7.EntitiesTask7.PressReleaseItems;

namespace Task7.Task7.EntitiesTask7
{
    public class EBook : IBook ,IBookClonable<EBook>
    {
        readonly static string IdentifierURL = "https://archive.org/details/";
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
        public List<Author>? Authors { get; set; }
        public string Identifier { get; set; }
        public int Pages { get; set; }
        public List<ElectronicFormat> ElectronicFormats { get; set;}
        public EBook(string title, List<Author>? authors, string identifier, List<ElectronicFormat> electronicFormats)
        {
            Title = title;
            Authors = authors == null ? new List<Author>() : new List<Author>(authors);
            Identifier = IdentifierURL+identifier;
            ElectronicFormats = new List<ElectronicFormat>(electronicFormats);
        }
        public override string ToString()
        {
            StringBuilder authors = new StringBuilder();
            StringBuilder formats = new StringBuilder();
            foreach (var author in Authors!)
            {
                authors.Append($"  - {author}\n");
            }
            foreach(var format in ElectronicFormats)
            {
                formats.Append($"  - {format}\n");
            }
            return $"Book: '{Title}', Identifier: {Identifier}, Pages number: {Pages}, Authors:\n{authors}\nElectronic Formats:\n{formats}";
        }

        async public Task FetchPagesNumber()
        {
            using HttpClient client = new HttpClient();
            try
            {
                var response = await client.GetStringAsync(Identifier);
                var match = Regex.Match(response, @"<span itemprop=""numberOfPages"">(\d+)</span>");
                if (match.Success && int.TryParse(match.Groups[1].Value, out int pages))
                {
                    Pages = pages;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error while fetching number of pages: {e.Message}");
            }
        }

        public EBook Clone(EBook book)
        {
            if(book != null)
            {
                return new EBook(book.Title, book.Authors, book.Identifier, book.ElectronicFormats);
            }
            else
            {
                throw new ArgumentException("Book can't be null");
            }
        }
    }
}
