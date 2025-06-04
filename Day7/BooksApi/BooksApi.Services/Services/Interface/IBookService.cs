using BooksApi.Entities.Entities;
using BooksApi.Models;

namespace BooksApi.Services.Services.Interface
{
    public interface IBookService
    {
        void AddBook(Book book);
        List<Book> GetAll();
        Book? GetBookById(int id);
        Task InsertBook(Book book);
        BookDetails GetBookDetailsById(int id);
        Task<List<Book>> GetAllAsync(); // Added async method for fetching all books
        Task GetAllBooks();
    }
}