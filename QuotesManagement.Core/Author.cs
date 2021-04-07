using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuotesManagement.Core
{
    public class Author
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }

        public ICollection<Quote> Quotes { get; set; }
    }
}
