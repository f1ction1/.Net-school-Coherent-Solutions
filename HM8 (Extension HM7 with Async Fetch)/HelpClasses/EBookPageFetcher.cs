using System.Text.RegularExpressions;
using Task7.Task7.EntitiesTask7;

namespace Task7.Task8.HelpClasses
{
    public class EBookPageFetcher
    {
        async public Task FetchPagesNumberAsync(EBook book)
        {
            using HttpClient client = new HttpClient();
            try
            {
                var response = await client.GetStringAsync(book.Identifier);
                var match = Regex.Match(response, @"<span itemprop=""numberOfPages"">(\d+)</span>");
                if (match.Success && int.TryParse(match.Groups[1].Value, out int pages))
                {
                    book.Pages = pages;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Request error while fetching number of pages: {e.Message}, Identifier: {book.Identifier}");
            }
        }
    }
}
