using Microsoft.EntityFrameworkCore;
using QuotesManagement.Core;
using System.Collections.Generic;
using System.Linq;

namespace QuotesManagement.Data
{
    public class SqlQuoteData : IQuoteData
    {
        private readonly QuotesManagementDbContext db;

        public SqlQuoteData(QuotesManagementDbContext db)
        {
            this.db = db;
        }

        // Committing Changes
        public int Commit()
        {
            return db.SaveChanges();
        }

        // Getting Specific Quote by its ID
        public Quote GetById(long id)
        {
            return db.Quotes.Include(q => q.Author).SingleOrDefault(q => q.Id == id);
        }

        /*
             Getting Specific Quote By Name (Used For Searching Box)
        */
        public IEnumerable<Quote> GetQuoteByName(string name)
        {
            return db.Quotes
                .Include(q => q.Author)
                .Where(r => string.IsNullOrWhiteSpace(name) || r.Title.Contains(name))
                .OrderBy(r => r.Title)
                .ToList();
        }

        // Adding the Quote
        public Quote Add(Quote newQuote)
        {
            db.Quotes.Add(newQuote);
            return newQuote;
        }

        // Updating The Quotes
        public Quote Update(Quote updatedQuote)
        {
            var entity = db.Quotes.Attach(updatedQuote);
            entity.State = EntityState.Modified;
            return updatedQuote;
        }

        // Getting All Quotes for the Author
        public IEnumerable<Quote> GetQuotesByAuthor(long authorId)
        {
            return db.Quotes
                .Include(q => q.Author)
                .Where(r => r.AuthorId == authorId)
                .OrderBy(r => r.Title)
                .ToList();
        }

        // Getting Random Quote
        public Quote GetRandomQuote()
        {
            var count = db.Quotes.Count();
            var random = new System.Random();
            return db.Quotes
                .Include(q => q.Author)
                .Skip(random.Next(count))
                .FirstOrDefault();
        }



        // Deleting the Quotes
        public Quote Delete(long id)
        {
            var quote = GetById(id);
            if (quote != null)
            {
                db.Quotes.Remove(quote);
            }
            return quote;
        }

        // Get All Quotes
        public ICollection<Quote> GetAllQuotes()
        {
            return db.Quotes.ToList();
        }

        // Getting Specific Quote by its ID
        public Quote GetByIdNoTracking(long id)
        {
            return db.Quotes.Include(q => q.Author).AsNoTracking().SingleOrDefault(q => q.Id == id);
        }
    }
}
