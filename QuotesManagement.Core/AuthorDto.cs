using System.ComponentModel.DataAnnotations;

namespace QuotesManagement.Core
{
    public class AuthorDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
