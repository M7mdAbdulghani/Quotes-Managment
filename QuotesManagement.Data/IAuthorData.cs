using QuotesManagement.Core;
using System.Collections.Generic;

namespace QuotesManagement.Data
{
    public interface IAuthorData
    {
        IEnumerable<Author> GetAuthorsByName(string name);
        Author Add(Author newAuthor);
        int Commit();
        Author GetById(long authorId);
        List<Author> GetAuthors();
    }
}
