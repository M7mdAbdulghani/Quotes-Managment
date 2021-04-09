using QuotesManagement.Core;

namespace QuotesManagement.API.Helpers
{
    public class AutoMapperConversion
    {
        public static Quote ToQuote(QuoteDto quote)
        {
            return new Quote()
            {
                Title = quote.Title,
                Content = quote.Content,
                AuthorId = quote.AuthorId
            };
        }

        public static Author ToAuthor(AuthorDto author)
        {
            return new Author()
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };
        }
    }
}
