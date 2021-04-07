using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuotesManagement.Core;
using QuotesManagement.Data;

namespace QuotesManagement.Pages.Quotes
{
    public class DetailModel : PageModel
    {
        public Quote Quote { get; set; }
        public IQuoteData QuoteData { get; }

        [TempData]
        public string Message { get; set; }

        public DetailModel(IQuoteData quoteData)
        {
            QuoteData = quoteData;
        }

        public IActionResult OnGet(long quoteID)
        {
            Quote = QuoteData.GetById(quoteID);

            if (Quote == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}
