using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuotesManagement.Core;
using QuotesManagement.Data;
using System.Collections.Generic;

namespace QuotesManagement.Pages.Quotes
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IQuoteData quoteData;
        private readonly IAuthorData authorData;

        [BindProperty]
        public Quote Quote { get; set; }
        public IEnumerable<Author> Authors { get; set; }

        public EditModel(IQuoteData quoteData, IAuthorData authorData)
        {
            this.quoteData = quoteData;
            this.authorData = authorData;
        }
        public IActionResult OnGet(long? quoteID)
        {
            Authors = authorData.GetAuthorsByName("");
            ViewData["Authors"] = new SelectList(Authors, "Id", "FirstName");

            if (quoteID.HasValue)
            {
                this.Quote = quoteData.GetById(quoteID.Value);
            }
            else
            {
                Quote = new Quote();
            }


            if (Quote == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }


        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                Authors = authorData.GetAuthorsByName("");
                ViewData["Authors"] = new SelectList(Authors, "Id", "FirstName");

                return Page();
            }

            if (Quote.Id > 0)
            {
                Quote = quoteData.Update(Quote);
            }
            else
            {
                quoteData.Add(Quote);
            }

            quoteData.Commit();
            TempData["Message"] = "Quote Saved";
            return RedirectToPage("./Detail", new { quoteID = Quote.Id });

        }
    }
}
