using QuotesManagement.Core;
using System.Collections.Generic;
using System.Linq;

namespace QuotesManagement.Data
{
    public class SqlAuthorData : IAuthorData
    {
        private readonly QuotesManagementDbContext db;

        public SqlAuthorData(QuotesManagementDbContext db)
        {
            this.db = db;
        }

        // Adding new Author
        public Author Add(Author newAuthor)
        {
            db.Authors.Add(newAuthor);
            return newAuthor;
        }

        // Committing Changes
        public int Commit()
        {
            return db.SaveChanges();
        }

        // Getting Authors By Name (Used in the Search Box)
        public IEnumerable<Author> GetAuthorsByName(string name)
        {
            return db.Authors
                    .OrderBy(q => q.Id)
                    .Where(r => string.IsNullOrWhiteSpace(name) || r.FirstName.StartsWith(name) || r.LastName.StartsWith(name))
                    .ToList();
        }

        // Getting Specific Author By ID
        public Author GetById(long authorId)
        {
            return db.Authors.Find(authorId);
        }

        public List<Author> GetAuthors()
        {
            return db.Authors.ToList();
        }
    }
}
