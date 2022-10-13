using System;
using BookManagerApi.Models;

namespace BookManagerApi.Services
{
    /// <summary>
    /// Interface IBookManagementService
    /// The class that implements this interface have to implements these method
    /// </summary>
	public interface IBookManagementService
	{
        List<Book> GetAllBooks();
        Book Create(Book book);
        Book Update(long id, Book book);
        Book FindBookById(long id);
        bool BookExists(long id);
        Book DeleteBookById(long id);
    }
}
