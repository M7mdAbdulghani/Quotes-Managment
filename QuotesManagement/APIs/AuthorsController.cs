using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuotesManagement.Core;
using QuotesManagement.Data;
using System.Collections.Generic;

namespace QuotesManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorData authorData;

        public AuthorsController(IAuthorData authorData)
        {
            this.authorData = authorData;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var data = authorData.GetAuthorsByName("");
            // Get how many items
            int count = new List<Author>(data).Count;
            return new OkObjectResult(new
            {
                success = true,
                message = "All Authors",
                count = count,
                data = data
            });
        }


        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var newAuthor = authorData.Add(author);
            authorData.Commit();

            return new OkObjectResult(new
            {
                success = true,
                message = "Author Added Successfully",
                data = newAuthor
            });
        }

    }
}
