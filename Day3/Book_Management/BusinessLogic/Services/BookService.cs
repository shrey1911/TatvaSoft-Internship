using Book_Management.Models;

namespace Book_Management.Services
{
    public class BookService
    {
        private List<Book> books;
        public BookService()
        {
            books = new List<Book>
            {
                new Book { Id = 1, Title = "1984", Author = "George Orwell", Genre = "Fiction" },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction" },
                new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Classic" }
            };
        }
        public List<Book> GetBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            Book book= books.FirstOrDefault(book=> book.Id == id);
            if (book == null)
            {
                return null;
            }
            return book;
        }

        public void AddBook(Book book)
        {
            book.Id = books.Count + 1;
            books.Add(book);
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
                books.Remove(bookToBeRemoved);
                return 1; // Book deleted successfully
            }
        }
    
    }

}
