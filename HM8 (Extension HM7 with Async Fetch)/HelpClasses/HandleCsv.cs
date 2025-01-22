using System.Globalization;
using System.Text.RegularExpressions;
using CsvHelper;
using Task7.Task7.Entities;
using Task7.Task7.EntitiesTask7;
using Task7.Task7.EntitiesTask7.PressReleaseItems;

namespace Task7.Task7.HelpClasses
{
    public class HandleCsv
    {
        static readonly string _filePath = "C:\\Users\\Game Station\\Desktop\\Coherent Solutions\\HM's\\HM7\\books_info.csv";
        static Regex _regexAuthor = new Regex(@"^[^\d]*$");

        public static (List<Publisher>, Dictionary<Isbn, PaperBook>) GetPaperBooksData()
        {
            Dictionary<Isbn, PaperBook> books = new Dictionary<Isbn, PaperBook>();
            List<Publisher> publishers = new List<Publisher>();
            using (var reader = new StreamReader(_filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Automatically map CSV data to dynamic objects
                var records = csv.GetRecords<dynamic>();
                foreach (var record in records)
                {
                    string title = string.Empty;
                    DateTime? publicationDate = null;
                    List<Author> authorList = new List<Author>();
                    List<Isbn> isbns = new List<Isbn>();
                    Publisher publisher = new Publisher();

                    foreach (var property in record)
                    {
                        if (property.Key == "creator")
                        {
                            var creators = new string(property.Value).Split(',');
                            foreach (var creator in creators)
                            {
                                if (_regexAuthor.IsMatch(creator))
                                {
                                    authorList.Add(new Author(creator, DateTime.Now));
                                }
                            }
                        }
                        if (property.Key == "publicdate")
                        {
                            var dates = new string(property.Value).Substring(0, 10).Split('-');

                            if (int.TryParse(dates[0], out int year) && int.TryParse(dates[1], out int month) && int.TryParse(dates[2], out int day))
                            {
                                publicationDate = new DateTime(year, month, day);
                            }
                        }
                        if (property.Key == "publisher")
                        {
                            publisher.Value = property.Value;
                            publishers.Add(new Publisher(property.Value));
                        }
                        if (property.Key == "related-external-id")
                        {
                            var stringIsbns = new string(property.Value).Split(',');
                            foreach (var stringIsbn in stringIsbns)
                            {
                                isbns.Add(new Isbn(Regex.Replace(stringIsbn, "[^0-9]", "")));
                            }
                        }
                        if (property.Key == "identifier")
                        {
                            title = new string(property.Value).Split('0')[0];
                        }
                    }
                    books.TryAdd(new Isbn(isbns[0].Value), new PaperBook(title, publicationDate, authorList, isbns, publisher));
                }
            }
            return (publishers, books);
        }

        public static (List<ElectronicFormat>, Dictionary<Isbn, EBook>) GetEBooksData()
        {
            Dictionary<Isbn, EBook> books = new Dictionary<Isbn, EBook>();
            List<ElectronicFormat> elFormats = new List<ElectronicFormat>();
            using (var reader = new StreamReader(_filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Automatically map CSV data to dynamic objects
                var records = csv.GetRecords<dynamic>();
                foreach (var record in records)
                {
                    string title = string.Empty;
                    List<Author> authorList = new List<Author>();
                    string identifier = string.Empty;
                    List<ElectronicFormat> localFormats = new List<ElectronicFormat>();
                    foreach (var property in record)
                    {
                        if (property.Key == "creator")
                        {
                            var creators = new string(property.Value).Split(',');
                            foreach (var creator in creators)
                            {
                                if (_regexAuthor.IsMatch(creator))
                                {
                                    authorList.Add(new Author(creator, DateTime.Now));
                                }
                            }
                        }
                        if (property.Key == "identifier")
                        {
                            title = new string(property.Value).Split('0')[0];
                            identifier = property.Value;
                        }
                        if(property.Key == "format")
                        {
                            var formats = new string(property.Value).Split(",");
                            foreach(var format in formats)
                            {
                                if (!elFormats.Contains(new ElectronicFormat(format)))
                                {
                                    elFormats.Add(new ElectronicFormat(format)); 
                                }
                                localFormats.Add(new ElectronicFormat(format));
                            }
                        }
                    }
                    books.TryAdd(new Isbn(identifier), new EBook(title, authorList, identifier, localFormats));
                }
            }
            return (elFormats, books);
        }
    }
}
