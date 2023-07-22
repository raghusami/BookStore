using Book_Store.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        // Step 1: Sorted list of books by Publisher, Author (last, first), then title.
        [HttpGet("sortedbypublisher")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksSortedByPublisher()
        {
            try
            {
                var result = await bookRepository.GetBooksSortedByPublisher();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // Step 2: Sorted list of books by Author (last, first), then title.
        [HttpGet("sortedbyauthor")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksSortedByAuthor()
        {
            try
            {
                var result = await bookRepository.GetBooksSortedByAuthor();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // Step 4: Sorted list of books by Publisher, Author (last, first), then title using store procedure.
        [HttpGet("spsortedbypublisher")]
        public async Task<ActionResult<IEnumerable<Book>>> SpGetBooksSortedByPublisher()
        {
            try
            {
                var result = await bookRepository.SpGetBooksSortedByPublisher();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // Step 4: Sorted list of books by Author (last, first), then title using store procedure.
        [HttpGet("spsortedbyauthor")]
        public async Task<ActionResult<IEnumerable<Book>>> SpGetBooksSortedByAuthor()
        {
            try
            {
                var result = await bookRepository.SpGetBooksSortedByAuthor();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        // Step 5: Total price of all books in the database.
        [HttpGet("totalprice")]
        public async Task<ActionResult<decimal>> GetTotalPriceOfBooks()
        {
            try
            {
                var totalPrice = await bookRepository.GetTotalPriceOfBooks();
                return Ok(totalPrice);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        //Step 6: New API method to save a large list of books
        [HttpPost("savelargelist")]
        public async Task<ActionResult> SaveLargeListOfBooks(IEnumerable<Book> books)
        {
            try
            {
                if (books == null)
                    return BadRequest();

                await bookRepository.AddBooks(books);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new book record");
            }
        }
    }
}

