using Book_Management.Models;
using Books.DataAccess;
using Books.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.services.Services
{
    public class BookServices
    {
        private readonly BooksRepository _booksRepository;

        public BookServices(BooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public List<Book> GetBooks()
        {
            return _booksRepository.GetBooks();
        }

        public Book GetBookById(int id)
        {
            return _booksRepository.GetBookById(id);
        }

        public void AddBook(Book book)
        {
            _booksRepository.AddBook(book);
            
        }

        public int UpdateBook(Book book)
        {
           return _booksRepository.UpdateBook(book);

        }

        public int DeleteBook(int id)
        {
           return _booksRepository.DeleteBook(id);
        }
    }
}
 