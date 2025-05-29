using Book_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Repositories
{
    public class BooksRepository
    {
        private readonly BooksDbContext _bookDbcontext;
        public BooksRepository(BooksDbContext bookDbcontext)
        {
            _bookDbcontext = bookDbcontext;
        }

         public List<Book> GetBooks()
        {
            return _bookDbcontext.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            Book book= _bookDbcontext.Books.FirstOrDefault(book=> book.Id == id);
            if (book == null)
            {
                return null;
            }
            return book;
        }

        public void AddBook(Book book)
        {

            var existingBook = _bookDbcontext.Books.Find(book.Id);
            if (existingBook != null)
            {
                throw new Exception("Book with this ID already exists.");
            }

            _bookDbcontext.Books.Add(book);
            _bookDbcontext.SaveChanges();
        }

        public int UpdateBook(Book book)
        {
            Book bookToBeUpdated =GetBookById(book.Id);
            if (bookToBeUpdated == null)
            {
                return -1; // Book not found
            }
            else
            {
                bookToBeUpdated.Title = book.Title;
                bookToBeUpdated.Author = book.Author;
                bookToBeUpdated.Genre = book.Genre;
                _bookDbcontext.SaveChanges();

                return 1; // Book updated successfully
            }
    
        }

        public int DeleteBook(int id)
        {
            Book bookToBeRemoved = GetBookById(id);
            if (bookToBeRemoved == null)
            {
                return -1; // Book not found
            }
            else
            {
                _bookDbcontext.Books.Remove(bookToBeRemoved);
                _bookDbcontext.SaveChanges();
                return 1; // Book deleted successfully
            }
        }
    }
}
