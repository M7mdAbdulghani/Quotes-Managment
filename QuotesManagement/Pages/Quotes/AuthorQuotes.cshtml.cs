using Microsoft.AspNetCore.Mvc.RazorPages;
using QuotesManagement.Core;
using QuotesManagement.Data;
using System.Collections.Generic;

namespace QuotesManagement.Pages.Quotes
{
    public class AuthorQuotesModel : PageModel
    {
        private readonly IQuoteData quoteData;

        public IEnumerable<Quote> Quotes { get; set; }

        public AuthorQuotesModel(IQuoteData quoteData)
        {
            this.quoteData = quoteData;
        }
        public void OnGet(long authorId)
        {
            this.Quotes = quoteData.GetQuotesByAuthor(authorId);
        }
    }
}
