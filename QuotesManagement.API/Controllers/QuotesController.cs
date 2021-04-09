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
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteData quoteData;
        private readonly IAuthorData authorData;

        public QuotesController(IQuoteData quoteData, IAuthorData authorData)
        {
            this.quoteData = quoteData;
            this.authorData = authorData;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var data = quoteData.GetQuoteByName("");
            // Get how many items
            int count = new List<Quote>(data).Count;
            return new OkObjectResult(new
            {
                success = true,
                message = "All Quotes",
                count = count,
                data = data
            });
        }

        [HttpGet("/api/quotes/GetRandomQuote")]
        public IActionResult GetRandomQuote()
        {
            var data = quoteData.GetRandomQuote();
            return new OkObjectResult(new
            {
                success = true,
                message = "Random Quote",
                data = data
            });
        }

        [HttpGet("/api/quotes/GetQuotesByAuthor/{authorId}")]
        public IActionResult GetQuotesByAuthor(long authorId)
        {
            var author = authorData.GetById(authorId);
            if (author == null)
            {
                return new NotFoundResult();
            }
            var data = quoteData.GetQuotesByAuthor(authorId);
            return new OkObjectResult(new
            {
                success = true,
                message = "Quotes By Author",
                data = data
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddQuote(QuoteDto quote)
        {
            if (quote.AuthorId == 0)
                return BadRequest(new
                {
                    success = false,
                    message = "Author ID is not specified"
                });

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var quoteFromDto = AutoMapperConversion.ToQuote(quote);

            var newQuote = quoteData.Add(quoteFromDto);
            quoteData.Commit();

            return new OkObjectResult(new
            {
                success = true,
                message = "Quote Added Successfully",
                data = newQuote
            });
        }

        [Authorize]
        [HttpPut("/api/quotes/{Id}")]
        public IActionResult UpdateQuote(long Id, QuoteDto quote)
        {
            if (quote.AuthorId == 0)
                return BadRequest(new
                {
                    success = false,
                    message = "Author ID is not specified"
                });

            var existingQuote = quoteData.GetByIdNoTracking(Id);

            if (existingQuote == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest("Invalid data. ");

            var quoteFromDto = AutoMapperConversion.ToQuote(quote);

            quoteFromDto.Id = existingQuote.Id;
            var updatedQuote = quoteData.Update(quoteFromDto);
            quoteData.Commit();

            return new OkObjectResult(new
            {
                success = true,
                message = "Quote Updated Successfully",
                data = updatedQuote
            });
        }

        [Authorize]
        [HttpDelete("/api/quotes/{Id}")]
        public IActionResult DeleteQuote(long Id)
        {
            var existingQuote = quoteData.GetById(Id);

            if (existingQuote == null)
            {
                return NotFound();
            }

            var deletedQuote = quoteData.Delete(Id);
            quoteData.Commit();

            return new OkObjectResult(new
            {
                success = true,
                message = "Quote Deleted Successfully"
            });
        }
    }
}
