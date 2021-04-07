using System.ComponentModel.DataAnnotations;

namespace QuotesManagement.Core
{
    public class Quote
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public long AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
