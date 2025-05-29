using Book_Management.Models;
using Books.services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Book_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookServices _bookService;

        public BookController(BookServices bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAllBooks")]
        public ActionResult<List<Book>> GetAllBooks()
        {
            List<Book> books = _bookService.GetBooks();
            if (books == null || books.Count == 0)
            {
                return NotFound("No books found.");
            }
            else
            {
                return Ok(books);
            }
        }
        [HttpGet("GetSinglBooks")]
        public ActionResult<Book> GetBook(int id)
        {
            Book book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound("Book not found.");
            }
            else
            {
                return Ok(book);
            }
        }

        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            _bookService.AddBook(book);
            return Ok("Book added successfully.");

        }

        [HttpPut]
        public ActionResult UpdateBook(Book bookToBeUpdated)
        {
            int bookUpdateStatus = _bookService.UpdateBook(bookToBeUpdated);
            if (bookUpdateStatus == -1)
            {
                return NotFound("Book not found.");
            }
            else if (bookUpdateStatus == 1)
            {
                return Ok("Book updated successfully.");
            }
            else
            {
                return BadRequest("Error updating book.");
            }
        }

        [HttpDelete]

        public ActionResult DeleteBook(int id)
        {
            int bookDeleteStatus = _bookService.DeleteBook(id);
            if (bookDeleteStatus == -1)
            {
                return NotFound("Book not found.");
            }
            else if (bookDeleteStatus == 1)
            {
                return Ok("Book deleted successfully.");
            }
            else
            {
                return BadRequest("Error deleting book.");
            }
        }

    }
}