using GraphQL.Models;

namespace GraphQL.Services
{
    public interface IBookService
    {
        IQueryable<Book> GetBooks();
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);
    }
}
