using QuotesManagement.Core;
using System.Collections.Generic;

namespace QuotesManagement.Data
{
    public interface IQuoteData
    {
        ICollection<Quote> GetAllQuotes();
        IEnumerable<Quote> GetQuotesByAuthor(long authorId);
        IEnumerable<Quote> GetQuoteByName(string name);
        Quote GetById(long id);
        Quote Update(Quote updatedQuote);
        int Commit();
        Quote Add(Quote newQuote);
        Quote Delete(long id);
        Quote GetRandomQuote();
        Quote GetByIdNoTracking(long id);
    }
}
