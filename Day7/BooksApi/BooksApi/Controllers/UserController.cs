using BooksApi.Data.Models;
using BooksApi.Services;
using BooksApi.Services.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService; // Added book service

        public UserController(IUserService userService, IBookService bookService) // Inject book service
        {
            _userService = userService;
            _bookService = bookService;
        }

        [HttpPost]
        [Route("all")]
        public async Task<IActionResult> GetAllUsers([FromBody] FilterVM filterRequest)
        {
            var data = await _userService.GetAllUsers(filterRequest);
            return Ok(data);
        }

        // Added: Get all books endpoint
        [HttpGet]
        [Route("books")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }
    }
}