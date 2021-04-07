using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuotesManagement.Core;
using QuotesManagement.Data;
using System.Collections.Generic;

namespace QuotesManagement.Pages.Authors
{
    public class ListModel : PageModel
    {
        private readonly IAuthorData authorData;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IEnumerable<Author> Authors { get; set; }

        public ListModel(IAuthorData authorData)
        {
            this.authorData = authorData;
        }
        public void OnGet()
        {
            this.Authors = authorData.GetAuthorsByName(SearchTerm);
        }
    }
}
