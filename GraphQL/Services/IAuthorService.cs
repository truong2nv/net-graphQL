using GraphQL.Models;

namespace GraphQL.Services
{
    public interface IAuthorService
    {
        IQueryable<Author> GetAuthors();
        Task<Author?> GetAuthorByIdAsync(int id);
        Task<Author> AddAuthorAsync(Author author);
    }
}
