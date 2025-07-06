using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _dbContext;

        public BookService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Book> GetBooks() => _dbContext.Books.AsQueryable();

        public async Task<Book?> GetBookByIdAsync(int id) => await _dbContext.Books.FindAsync(id);

        public async Task<Book> AddBookAsync(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            _dbContext.Entry(book).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var bookToRemove = await _dbContext.Books.FindAsync(id);
            if (bookToRemove != null)
            {
                _dbContext.Books.Remove(bookToRemove);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
