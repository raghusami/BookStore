using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Models
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksSortedByAuthor();
        Task<IEnumerable<Book>> GetBooksSortedByPublisher();
        Task<IEnumerable<Book>> SpGetBooksSortedByAuthor();
        Task<IEnumerable<Book>> SpGetBooksSortedByPublisher();
        Task<decimal> GetTotalPriceOfBooks();
        Task AddBooks(IEnumerable<Book> books);
    }
}
