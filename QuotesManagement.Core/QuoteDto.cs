using System.ComponentModel.DataAnnotations;

namespace QuotesManagement.Core
{
    public class QuoteDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public long AuthorId { get; set; }
    }
}
