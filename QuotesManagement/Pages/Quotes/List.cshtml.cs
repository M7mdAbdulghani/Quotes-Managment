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
    public class ListModel : PageModel
    {
        private readonly IQuoteData quoteData;
        private readonly IAuthorData authorData;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public string authorId { get; set; }


        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Quote> Quotes { get; set; }

        public ListModel(IQuoteData quoteData, IAuthorData authorData)
        {
            this.quoteData = quoteData;
            this.authorData = authorData;
        }
        public void OnGet()
        {
            Authors = authorData.GetAuthorsByName("");
            ViewData["Authors"] = new SelectList(Authors, "Id", "FirstName");

            if (authorId == null)
                authorId = authorData.GetAuthors().Count > 0 ? authorData.GetAuthors()[0].Id.ToString() : "0";

            this.Quotes = quoteData.GetQuoteByName(SearchTerm);
        }
    }
}
