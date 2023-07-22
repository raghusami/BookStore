using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext appDbContext;
        public BookRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task AddBooks(IEnumerable<Book> books)
        {
            await appDbContext.Books.AddRangeAsync(books);
            await appDbContext.SaveChangesAsync();

        }
        public async Task<IEnumerable<Book>> GetBooksSortedByAuthor()
        {
            return await appDbContext.Books.OrderBy(x => x.Publisher)
                                           .ThenBy(x => x.AuthorLastName)
                                           .ThenBy(x => x.AuthorFirstName)
                                           .ThenBy(x => x.Title)
                                           .ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetBooksSortedByPublisher()
        {
            return await appDbContext.Books.OrderBy(x => x.AuthorLastName)
                                          .ThenBy(x => x.AuthorFirstName)
                                          .ThenBy(x => x.Title)
                                          .ToListAsync();
        }
        public async Task<IEnumerable<Book>> SpGetBooksSortedByAuthor()
        {
            return await appDbContext.Books.FromSqlRaw<Book>("sp_GetBooksSortedByAuthor")
                                           .ToListAsync();
        }
        public async Task<IEnumerable<Book>> SpGetBooksSortedByPublisher()
        {
            return await appDbContext.Books.FromSqlRaw<Book>("sp_GetBooksSortedByPublisher")
                                           .ToListAsync();
        }
        public async Task<decimal> GetTotalPriceOfBooks()
        {
            return await appDbContext.Books.SumAsync(b => b.Price);
        }
    }
}
