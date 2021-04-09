using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuotesManagement.API.Helpers;
using QuotesManagement.Core;
using QuotesManagement.Data;
using System.Collections.Generic;

namespace QuotesManagement.Controllers
{
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


        [Authorize]
        [HttpPost]
        public IActionResult AddAuthor(AuthorDto author)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var authoFromDto = AutoMapperConversion.ToAuthor(author);

            var newAuthor = authorData.Add(authoFromDto);
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
