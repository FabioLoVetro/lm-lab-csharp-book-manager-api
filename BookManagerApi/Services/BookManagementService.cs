using BookManagerApi.Models;

namespace BookManagerApi.Services
{
    /// <summary>
    /// Class BookManagementService implements IBookManagementService
    /// </summary>
	public class BookManagementService : IBookManagementService
	{
        private readonly BookContext _context;

        /// <summary>
        /// Constructor
        /// instantiate and set the attributes context
        /// </summary>
        /// <param name="context"></param>
        public BookManagementService(BookContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GetAllBooks method return a list with all the books
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAllBooks()
        {
            var books = _context.Books.ToList();
            return books;
        }

        /// <summary>
        /// Create method adds a new book to the context and returns it
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public Book Create(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
            return book;
        }

        /// <summary>
        /// Update method apdate a book,
        /// Finds the book to update by di and than update it with the book
        /// passed as parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        public Book Update(long id, Book book)
        {
            var existingBookFound = FindBookById(id);

            existingBookFound.Title = book.Title;
            existingBookFound.Description = book.Description;
            existingBookFound.Author = book.Author;
            existingBookFound.Genre = book.Genre;

            _context.SaveChanges();
            return book;
        }

        /// <summary>
        /// FindBookById method return the book which has the 
        /// id equal to the id passed as parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book FindBookById(long id)
        {
            var book = _context.Books.Find(id);
            return book;
        }

        /// <summary>
        /// public Book DeleteBookById(long id) method checks if exists
        /// a book with the id equal to the id passes as parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool BookExists(long id)
        {
            return _context.Books.Any(b => b.Id == id);
        }

        /// <summary>
        /// public Book DeleteBookById(long id) method
        /// delete the book with the id equal to the id passed
        /// as parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book DeleteBookById(long id)
        {
            var book = FindBookById(id);
            _context.Remove(book);
            _context.SaveChanges();
            return book;
        }
    }
}

