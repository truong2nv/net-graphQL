using GraphQL.Models;

namespace GraphQL.Services
{
    public class AuthorService(AppDbContext dbContext) : IAuthorService
    {
        private readonly AppDbContext _dbContext = dbContext;

        public IQueryable<Author> GetAuthors() => _dbContext.Authors.AsQueryable();

        public async Task<Author?> GetAuthorByIdAsync(int id) => await _dbContext.Authors.FindAsync(id);

        public async Task<Author> AddAuthorAsync(Author author)
        {
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
            return author;
        }
    }
}
