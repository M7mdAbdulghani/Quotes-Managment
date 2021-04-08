using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuotesManagement.Core;
using QuotesManagement.Data;

namespace QuotesManagement.Pages.Quotes
{
    [Authorize]
    public class RandomQuoteModel : PageModel
    {
        private readonly IQuoteData quoteData;
        public Quote Quote { get; set; }

        public RandomQuoteModel(IQuoteData quoteData)
        {
            this.quoteData = quoteData;
        }
        public IActionResult OnGet()
        {
            Quote = quoteData.GetRandomQuote();
            if (Quote == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
