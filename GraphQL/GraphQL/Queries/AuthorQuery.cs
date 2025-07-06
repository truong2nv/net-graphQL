using GraphQL.Models;
using GraphQL.Services;

namespace GraphQL.GraphQL.Queries
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class AuthorQuery
    {
        [GraphQLDescription("Gets all available authors.")]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Author> GetAuthors([Service] IAuthorService authorService) => authorService.GetAuthors();

        [GraphQLDescription("Gets an author by their unique ID.")]
        public async Task<Author?> GetAuthorAsync(int id, [Service] IAuthorService authorService) => await authorService.GetAuthorByIdAsync(id);
    }
}
