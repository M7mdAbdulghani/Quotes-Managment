using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuotesManagement.Core;
using QuotesManagement.Data;

namespace QuotesManagement.Pages.Quotes
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IQuoteData quoteData;
        public Quote Quote { get; set; }

        public DeleteModel(IQuoteData quoteData)
        {
            this.quoteData = quoteData;
        }
        public IActionResult OnGet(long quoteId)
        {
            Quote = quoteData.GetById(quoteId);
            if (Quote == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(long quoteId)
        {
            var quote = quoteData.Delete(quoteId);
            quoteData.Commit();

            if (quote == null)
            {
                return RedirectToPage("./NotFound");
            }

            return RedirectToPage("./List");
        }
    }
}
