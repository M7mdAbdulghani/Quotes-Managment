using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuotesManagement.Core;
using QuotesManagement.Data;

namespace QuotesManagement.Pages.Authors
{
    public class EditModel : PageModel
    {
        private readonly IAuthorData authorData;

        [BindProperty]
        public Author Author { get; set; }

        public EditModel(IAuthorData authorData)
        {
            this.authorData = authorData;
        }

        public IActionResult OnGet()
        {

            Author = new Author();
            return Page();
        }


        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            authorData.Add(Author);
            authorData.Commit();
            return RedirectToPage("./List");
        }
    }
}
